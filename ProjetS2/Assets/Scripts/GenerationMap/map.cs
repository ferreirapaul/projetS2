using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;


public class Map 
{
    List<List<Tile>>    TileGrid;       // liste contenant les listes de cases
    List<City>          ListOfCities;   // liste contenant les cases avec des villes 
    List<List<int>>     noise_grid;     // liste contenant les valeurs generes avec le bruit de perlin

    int     numberOfPlayers;
    int     amountOfCities;

    int     map_width;                  // nb de cases en largeur
    int     map_height;                 // nb de cases en hauteur
    float   magnification;              // l'effet de zoom ou dezoom sur la map
    int     seed;                       // la graine untilisee pour la generation 


    SpriteRenderer   spriteRenderer;

    List<int>        playerIDs;
    LobbyInfos       lobby;
    Network_global   network;
    List<Player>     playersList;

    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tile_groups;

    public Map(int map_width,int Map_height,int NumberOfPlayers,SpriteRenderer SpriteRenderer,Dictionary<int, GameObject> Tileset,Dictionary<int, GameObject> tileGroups,int Seed = -1,float Magnification = 10.0f)
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
        lobby           = FindObjectOfType<LobbyInfos>();
        network         = FindObjectOfType<Network_global>();
        spriteRenderer  = SpriteRenderer;
        map_width       = spriteRenderer.transform.localScale.x;
        map_height      = spriteRenderer.transform.localScale.y;
        tileset         = Tileset;
        tile_groups     = tileGroups;
        

        foreach(int key in lobby.players.Keys)
        {
            playerIDs.Add(key);
        }


        foreach (int playerID in playerIDs){
            playersList.Add(lobby.players[playerID]);
        }
        
        
        GenerateMap();
        generateFogOfWar();
        generateCities(amountOfCities);
        ChooseStartingCity();


    }

    private void GenerateMap()
    {
        for(int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<int>());
            TileGrid.Add(new List<tile>());

            for(int y = 0; y < map_height; y++)
            {
                int tile_id = GetAltitudeIdUsingPerlin(x, y);
                noise_grid[x].Add(tile_id);
                TileGrid[x].Add(new tile(tile_id,x,y));
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
                    TileGrid[x][y].FogOfWar = false;
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
                    TileGrid[x][y].FogOfWar = true;
                }
            }            
        }
    }

    bool cityIsValid (City city)
    {
        int     id      = city.tile_id;
        bool    valid   = true;
        int     index   = 0;
        while(index < cities.Count && valid )
        {
            if( getDistanceSquared(cities[index].posX,cities[index].posY,city.posX,city.posY) < 500 || id > 3)
            {
                valid = false;
            }
            index++;
        }
        return valid;
    }

    void generateCities (int amount)
    {
        int Count = 0;
        while(amount > 0 && Count < 10000)
        {
            int x       = (int) Random.Range(0, map_width);
            int y       = (int) Random.Range(0, map_height);
            City city   = new City(10,x,y);
            if (cityIsValid(city))
            {
                cities.Add(city);
                amount--;
            }
            Count++;
        }

    
    }

    List<City> GetStartingCities()
    {        
        int playerID = network.Client.myId;
        int playerNumber = 0;
        while (playerNumber<playerIDs.Count && playerID != playerIDs[playerNumber])
        {
            playerNumber++;
        }
        List<City> citiesToChooseFrom = new List<City>
        {
            cities[playerNumber],
            cities[playerNumber+1],
            cities[playerNumber+2],
        };

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