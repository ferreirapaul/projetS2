using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;


public class Tile 
{
    public bool FogOfWar;

    public GameObject gameObject;

    public int posX;
    public int posY;

    public GameObject tile_prefab;
    public GameObject tile_group;

    public int tile_id;

    public Tile(int tile_id,int posX,int posY)
    {
        this.tile_id= tile_id;
        FogOfWar    = true;
        this.posX   = posX;
        this.posY   = posY;
        tile_prefab = tileset[tile_id];
        tile_group  = tile_groups[tile_id];
        gameObject  = Instantiate(tile_prefab, tile_group.transform);
        tile.name   = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);
    }


 
        
 

}