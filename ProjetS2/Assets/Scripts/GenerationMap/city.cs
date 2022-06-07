using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class City : Tile
{
    private int health;
    public int ID;
    private Player owner;
    private List<Building.Building> builtBuildings;

    public int Health
    {
        get => this.health;
        set => this.health = value;
    }

    public Player Owner
    {
        get => this.owner;
        set => this.owner = value;
    }


    public City(int tile_id,int posX,int posY,Dictionary<int, GameObject> tileset,Dictionary<int, GameObject> tile_groups,int id,Player Owner)
    : base (tile_id,posX,posY,tileset,tile_groups)
    {
        this.ID = id;
        this.health = 100;
        this.owner = Owner;
        this.builtBuildings = new List<Building.Building>();
    }
}