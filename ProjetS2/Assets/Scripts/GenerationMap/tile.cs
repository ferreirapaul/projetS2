using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile 
{
    public bool FogOfWar;

    public GameObject gameObject;

    public int posX;
    public int posY;

    public GameObject tile_prefab;
    public GameObject tile_group;

    public int tile_id;

    public Tile(int tile_id,int posX,int posY,Dictionary<int, GameObject> tileset,Dictionary<int, GameObject> tile_groups)
    {
        this.tile_id= tile_id;
        FogOfWar    = true;
        this.posX   = posX;
        this.posY   = posY;
        tile_prefab = tileset[tile_id];
        tile_group  = tile_groups[tile_id];
        gameObject  = GameObject.Instantiate(tile_prefab, tile_group.transform);
        gameObject.name   = string.Format("tile_x{0}_y{1}", posX, posY);
        gameObject.transform.localPosition = new Vector2(posX, posY);
        setFOW(FogOfWar);
    }

    public void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void setFOW(bool b)
    {
        FOW f = gameObject.GetComponent<FOW>();
        Debug.Log(b);
        Debug.Log(f);
        f.setFOW(b);
    }
}