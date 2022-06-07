using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;


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
    public GameObject Fog_Of_War;
    public GameObject City;


    public SpriteRenderer spriteRenderer;


    /** changing this seed will offset the base coordinates of the perlin nois function by the given amount
        the same see will always generate the same map **/
    
    public int seed = -1; 
    public float magnification = 10.0f;

    public int map_height;
    public int map_width;
    public int numberOfPlayers;

    public Map map;

 
    public void Generate(int seed)
    {
        
        LobbyInfos lobby        = FindObjectOfType<LobbyInfos>();
        Network_global network  = FindObjectOfType<Network_global>();

        
        if (seed == -1)
        {
            seed = Random.Range(0, 1000);
        }
        CreateTileset();
        CreateTileGroups();

        this.map = new Map(map_width,map_height,numberOfPlayers,spriteRenderer,tileset,tile_groups,seed,magnification,lobby,network);
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
}
