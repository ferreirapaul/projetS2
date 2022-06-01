using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenMapScript : MonoBehaviour
{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tile_groups;

    public int amountOfCities;


    public GameObject Desert;
    public GameObject Jungle;
    public GameObject Plains;
    public GameObject Snow;
    public GameObject Desert_Hill;
    public GameObject Jungle_Hill;
    public GameObject Plains_Hill;
    public GameObject Snow_Hill;
    public GameObject Deep_Ocean;
    public GameObject Shallow_Ocean;
    public GameObject Fog_Of_War;

    public GameObject City;

    public SpriteRenderer spriteRenderer;
    private float map_width = 160f;   // value is the amount of tiles 
    private float map_height = 90f;
    public float magnification = 10.0f;  // recommend 4 to 20
 
    List<List<int>> noise_grid = new List<List<int>>();
    List<List<GameObject>> tile_grid = new List<List<GameObject>>();
    List<List<GameObject>> FogOfWar_grid = new List<List<GameObject>>();

    /** changing this seed will offset the base coordinates of the perlin nois function by the given amount
        the same see will always generate the same map **/
    
    public int seed = -1; 

 
    void Start()
    {
        map_width = spriteRenderer.transform.localScale.x;
        map_height = spriteRenderer.transform.localScale.y;
        if (seed == -1)
        {
            seed = Random.Range(0, 1000);
        }
        CreateTileset();
        CreateTileGroups();
        GenerateMap();
        generateFogOfWar();
        generateCities(amountOfCities);

    }
 
    void CreateTileset()
    {
        /** Collect and assign ID codes to the tile prefabs, for ease of access.
            Best ordered to match land elevation. **/
 
        tileset = new Dictionary<int, GameObject>();
        tileset.Add(0, Snow);
        tileset.Add(1, Plains);
        tileset.Add(2, Jungle);
        tileset.Add(3, Desert);
        tileset.Add(4, Snow_Hill);
        tileset.Add(5, Plains_Hill);
        tileset.Add(6, Jungle_Hill);
        tileset.Add(7, Desert_Hill);
        tileset.Add(8, Shallow_Ocean);
        tileset.Add(9, Deep_Ocean);
        tileset.Add(10, City);
    }
 
    void CreateTileGroups()
    {
        /** Create empty gameobjects for grouping tiles of the same type, ie
            forest tiles **/
 
        tile_groups = new Dictionary<int, GameObject>();
        foreach(KeyValuePair<int, GameObject> prefab_pair in tileset)
        {
            GameObject tile_group = new GameObject(prefab_pair.Value.name);
            tile_group.transform.parent = gameObject.transform;
            tile_group.transform.localPosition = new Vector3(0, 0, 0);
            tile_groups.Add(prefab_pair.Key, tile_group);
        }
    }
 
    void GenerateMap()
    {
        /** Generate a 2D grid using the Perlin noise fuction, storing it as
            both raw ID values and tile gameobjects **/
 
        for(int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<int>());
            tile_grid.Add(new List<GameObject>());
 
            for(int y = 0; y < map_height; y++)
            {
                int tile_id = GetAltitudeIdUsingPerlin(x, y);
                noise_grid[x].Add(tile_id);
                CreateTile(tile_id, x, y);
            }
        }
    }
 
    int GetAltitudeIdUsingPerlin(int x, int y)
    {
        /** Using a grid coordinate input, generate a Perlin noise value to be
            converted into a tile ID code. Rescale the normalised Perlin value
            to the number of tiles available. **/
 
        float raw_perlin = Mathf.PerlinNoise(
            (x - seed) / magnification,
            (y - seed) / magnification
        );
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
 
    int GetTemperatureIdUsingPerlin(int x,int y, bool mountain)
    {
        /** Using a grid coordinate input, generate a Perlin noise value to be
            converted into a tile ID code. Rescale the normalised Perlin value
            to the number of tiles available. **/
 
        float raw_perlin = Mathf.PerlinNoise(
            (x - seed) / magnification,
            (y - seed) / magnification
        );
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


    void CreateTile(int tile_id, int x, int y)
    {
        /** Creates a new tile using the type id code, group it with common
            tiles, set it's position and store the gameobject. **/
 
        GameObject tile_prefab = tileset[tile_id];
        GameObject tile_group = tile_groups[tile_id];
        GameObject tile = Instantiate(tile_prefab, tile_group.transform);
 
        tile.name = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);
        if(tile_id == 10)
        {    
            tile.transform.localPosition = new Vector3(x, y, -1);        
        }
        else
        {
            tile.transform.localPosition = new Vector3(x, y, 0);
        }
 
        tile_grid[x].Add(tile);
    }


    int getDistanceSquared ((int,int) city1 , (int,int) city2)
    {
        return (city1.Item1-city2.Item1)*(city1.Item1-city2.Item1) + (city1.Item2-city2.Item2)*(city1.Item2-city2.Item2);
    }

    bool cityIsValid ((int,int) Couple, List<(int,int)> cities )
    {
        int id = GetAltitudeIdUsingPerlin(Couple.Item1,Couple.Item2);
        bool valid  = true;
        int index = 0;
        while(index < cities.Count && valid )
        {
            //Debug.Log("distance between" + cities[index] + " and " + Couple + " is : " + getDistanceSquared(cities[index],Couple));
            if( getDistanceSquared(cities[index],Couple) < 500 || id > 3)
            {
                valid = false;
            }
            index++;
        }

        
        return valid;
    }

    void generateCities (int amount)
    {
        List<(int,int)> cities = new List<(int,int)>{};
        int Count = 0;
        while(amount > 0 && Count < 10000)
        {
            int x = (int) Random.Range(0, map_width);
            int y = (int) Random.Range(0, map_height);
            if (  cityIsValid( (x,y) ,  cities) ) {
                CreateTile(10,x,y);
                AddVision(x,y);
                cities.Add((x,y));
                amount--;
            }
            Count++;

        }
    }

    void generateFogOfWar()
    {
        GameObject tile_group = new GameObject(Fog_Of_War.name);
        tile_group.transform.parent = gameObject.transform;
        tile_group.transform.localPosition = new Vector3(0, 0, 0);
        tile_groups.Add(11, tile_group);
        

        GameObject tile_prefab = Fog_Of_War;


        for(int x = 0; x < map_width; x++)
        {
            FogOfWar_grid.Add(new List<GameObject>());
            for(int y = 0; y < map_height; y++)
            {
                GameObject tile = Instantiate(tile_prefab, tile_group.transform);
        
                tile.name = string.Format("tile_x{0}_y{1}", x, y);
                tile.transform.localPosition = new Vector3(x, y, -2);
        
                FogOfWar_grid[x].Add(tile);
            }
        }
    }

    void AddVision(int posX,int posY)
    {
        for(int x = posX-1; x <= posX + 1; x++)
        {
            for(int y = posY-1; y <= posY + 1; y++)
            {
                if (x >= 0 && x <= map_width && y >= 0 && y <= map_height)
                {
                    FogOfWar_grid[x][y].transform.localPosition = new Vector3(x,y,1);
                }
            }            
        }
    }

    void RemoveVision(int posX,int posY)
    {
        for(int x = posX-1; x <= posX + 1; x++)
        {
            for(int y = posY-1; y <= posY + 1; y++)
            {
                if (x >= 0 && x <= map_width && y >= 0 && y <= map_height)
                {
                    FogOfWar_grid[x][y].transform.localPosition = new Vector3(x,y,-2);
                }
            }            
        }
    }






}
