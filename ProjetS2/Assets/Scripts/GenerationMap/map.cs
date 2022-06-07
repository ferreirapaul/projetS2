using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;


public class Map 
{
    public List<List<Tile>>    TileGrid;       // liste contenant les listes de cases
    public List<City>          ListOfCities;   // liste contenant les cases avec des villes 
    public List<List<int>>     noise_grid;     // liste contenant les valeurs generes avec le bruit de perlin

    public int     numberOfPlayers;
    public int     amountOfCities;

    public int     map_width;                  // nb de cases en largeur
    public int     map_height;                 // nb de cases en hauteur
    public float   magnification;              // l'effet de zoom ou dezoom sur la map
    public int     seed;                       // la graine untilisee pour la generation 


    public SpriteRenderer   spriteRenderer;

    public List<int>        playerIDs;
    public LobbyInfos       lobby;
    public Network_global   network;
    public List<Player>     playersList;

    public Dictionary<int, GameObject> tileset;
    public Dictionary<int, GameObject> tile_groups;

    public Map(int Map_width,int Map_height,int NumberOfPlayers,SpriteRenderer SpriteRenderer,Dictionary<int, GameObject> Tileset,Dictionary<int, GameObject> tileGroup,int Seed,float Magnification,LobbyInfos lobby,Network_global network)
    {
        seed            = Seed;
        map_width       = Map_width;
        map_height      = Map_height;
        magnification   = Magnification;
        numberOfPlayers = NumberOfPlayers;
        amountOfCities  = NumberOfPlayers * 3;
        TileGrid        = new List<List<Tile>>();
        ListOfCities    = new List<City>();
        noise_grid      = new List<List<int>>();
        playersList     = new List<Player>{};
        spriteRenderer  = SpriteRenderer;
        tileset         = Tileset;
        tile_groups     = tileGroup;
        this.lobby      = lobby;
        this.network    = network;
        playerIDs       = new List<int>();



        foreach(int key in lobby.players.Keys)
        {
            playerIDs.Add(key);
        }


        foreach (int playerID in playerIDs){
            playersList.Add(lobby.players[playerID]);
        }
        
        if (seed == -1)
        {
            seed = Random.Range(0, 1000);
        }


        GenerateMap();
        generateCities(amountOfCities);
        ChooseStartingCity();


    }

    private void GenerateMap()
    {
        for(int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<int>());
            TileGrid.Add(new List<Tile>());

            for(int y = 0; y < map_height; y++)
            {
                int tile_id = GetAltitudeIdUsingPerlin(x, y);
                noise_grid[x].Add(tile_id);
                TileGrid[x].Add(new Tile(tile_id,x,y,tileset,tile_groups));
            }
        }
    }

    private int GetAltitudeIdUsingPerlin(int x, int y)
    {
        float raw_perlin = Mathf.PerlinNoise((x - seed) / magnification,(y - seed) / magnification);
        float clamp_perlin = Mathf.Clamp01(raw_perlin); 
        int id;
        
        if (clamp_perlin<0.1)
        {
            id = 9; // id 9 is deep ocean
        }
        else
        {
            if  (clamp_perlin<0.2)
            {
                id = 8; // id 8 is shallow ocean
            }
            else
            {
                if  (clamp_perlin<0.25) 
                {
                    id = 3; // id 3 is desert/sand and this way it will make beaches around bodies of water
                }else
                {
                    if  (clamp_perlin>0.8)
                    {
                        id = GetTemperatureIdUsingPerlin(x+1000,y+1000,true); // this generates terrain based on temperature with a Hill / mountain
                    }
                    else
                    {
                        id = GetTemperatureIdUsingPerlin(x+1000,y+1000,false); // this generates terrain based on temperature
                    }
                }
            }
        }
        return id;
    }
 
    private int GetTemperatureIdUsingPerlin(int x,int y, bool mountain)
    {
        /** Using a grid coordinate input, generate a Perlin noise value to be
            converted into a tile ID code. Rescale the normalised Perlin value
            to the number of tiles available. **/
 
        float raw_perlin = Mathf.PerlinNoise((x - seed) / magnification,(y - seed) / magnification);
        float clamp_perlin = Mathf.Clamp01(raw_perlin); 
        float scaled_perlin = clamp_perlin * 4;
 
        // Replaced 4 with tileset.Count to make adding tiles easier
        if(scaled_perlin == 4)
        {
            scaled_perlin = (3);
        }
        int id = Mathf.FloorToInt(scaled_perlin);
        if (mountain)
        {
            id +=4;
        }
        return id;
    }
    private int getDistanceSquared (int x1,int y1,int x2,int y2)
    {
        return (x1-x2)*(x1-x2)+(y1-y2)*(y1-y2);
    }

    public void AddVision(int posX,int posY, int VisionRange = 1)
    {
        for(int x = posX-VisionRange; x <= posX + VisionRange; x++)
        {
            for(int y = posY-VisionRange; y <= posY + VisionRange; y++)
            {
                if (x >= 0 && x < map_width && y >= 0 && y < map_height)
                {
                    TileGrid[x][y].setFOW(false);

                    foreach (City city in ListOfCities)
                    {
                        if (city.posX == x && city.posY == y)
                        {
                            city.setFOW(false);
                        }
                    }
                }
            }            
        }
    }

    public void RemoveVision(int posX,int posY, int VisionRange = 1)
    {
        for(int x = posX-VisionRange; x <= posX + VisionRange; x++)
        {
            for(int y = posY-VisionRange; y <= posY + VisionRange; y++)
            {
                if (x >= 0 && x < map_width && y >= 0 && y < map_height)
                {
                    TileGrid[x][y].setFOW(true);

                    foreach (City city in ListOfCities)
                    {
                        if (city.posX == x && city.posY == y)
                        {
                            city.setFOW(true);
                        }
                    }
                }
            }            
        }
    }

    bool cityIsValid (City city)
    {
        int     tile_id = TileGrid[city.posX][city.posY].tile_id;
        bool    valid   = true;
        int     index   = 0;
        while(index < ListOfCities.Count && valid )
        {
            
            if( getDistanceSquared(ListOfCities[index].posX,ListOfCities[index].posY,city.posX,city.posY) < 500 || tile_id > 3)
            {
                Debug.Log("City at x = "+ city.posX+" ; y = " + city.posY + " is invalid");
                valid = false;
            }
            index++;
        }
        return valid;
    }

    void generateCities (int amount)
    {
        Debug.Log("amount = " + amount);
        int Count = 0;
        while(amount > 0 && Count < 100000)
        {
            int x       = (int) Random.Range(0, map_width);
            int y       = (int) Random.Range(0, map_height);
            City city   = new City(10,x,y,tileset,tile_groups,amount,null);
            if (cityIsValid(city))
            {
                ListOfCities.Add(city);
                amount--;
            }
            else
            {
                city.Destroy();
                city=null;
            }
            Count++;
        }
        Debug.Log(Count);
    
    }

    List<City> GetStartingCities()
    {        
        int playerID = network.Client.myId;
        int playerNumber = 0;
        Debug.Log("playerID.Count = "+playerIDs.Count);
        while (playerNumber<playerIDs.Count-1 && playerID != playerIDs[playerNumber])
        {
            playerNumber++;
        }
        
        Debug.Log(ListOfCities.Count);
        List<City> citiesToChooseFrom = new List<City>{};
        Debug.Log("playernumber = "+playerNumber);
        int i =0;
        while (citiesToChooseFrom.Count <= 3 && playerNumber*3+i <ListOfCities.Count)
        {
            citiesToChooseFrom.Add(ListOfCities[playerNumber*3+i]);
            i++;
        }

        return citiesToChooseFrom;
    }

    void ChooseStartingCity ()
    {
        List<City> startingCities = GetStartingCities();
        foreach (City city in startingCities)
        {
            AddVision(city.posX,city.posY,10);
        }
    }

    public void SelectCity(City city)
    {
        return;
    }
}