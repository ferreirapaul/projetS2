using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class City : Tile
{
    public int id;
    public City(int tile_id,int posX,int posY,Dictionary<int, GameObject> tileset,Dictionary<int, GameObject> tile_groups,int id)
    : base (tile_id,posX,posY,tileset,tile_groups)
    {
        this.id = id;
    }
}