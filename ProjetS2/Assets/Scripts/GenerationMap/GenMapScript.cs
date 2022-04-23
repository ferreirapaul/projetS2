using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/* Danndx 2021 (youtube.com/danndx)
From video: youtu.be/qNZ-0-7WuS8
thanks - delete me! :) */
 
public class GenMapScript : MonoBehaviour
{
    Dictionary<int, GameObject> tileset;
    Dictionary<int, GameObject> tile_groups;

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
 
    public int map_width = 160;   // value is the amount of tiles 
    public int map_height = 90;
    public float magnification = 15.0f;  // recommend 4 to 20
 
    List<List<int>> noise_grid = new List<List<int>>();
    List<List<GameObject>> tile_grid = new List<List<GameObject>>();

    /** changing this seed will offset the base coordinates of the perlin nois function by the given amount
        the same see will always generate the same map **/
    
    public int seed = -1; 

 
    void Start()
    {
        if (seed == -1)
        {
            seed = Random.Range(0, 1000);
        }
        CreateTileset();
        CreateTileGroups();
        GenerateMap();
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
                if  (clamp_perlin<0.33) 
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
        float clamp_perlin = Mathf.Clamp01(raw_perlin); // Thanks: youtu.be/qNZ-0-7WuS8&lc=UgyoLWkYZxyp1nNc4f94AaABAg
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
 
        tile_grid[x].Add(tile);
    }
}
