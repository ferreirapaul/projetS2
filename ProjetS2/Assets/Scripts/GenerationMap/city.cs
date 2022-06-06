using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network;


public class City : Tile
{
    public City(int tile_id,int posX, int posY)
    {
        FogOfWar        = true;
        tile_prefab     = tileset[tile_id];
        tile_group      = tile_groups[tile_id];
        tile            = Instantiate(tile_prefab, tile_group.transform);
        tile.name       = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, -1);
    } 
}