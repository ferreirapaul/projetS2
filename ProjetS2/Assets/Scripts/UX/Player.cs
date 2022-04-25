using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string Name;
    public int Id;
    public int Emperor;

    public Player(List<string> values)
    {
        this.Name = values[0];
        this.Emperor = Int32.Parse(values[1]);
        this.Id = Int32.Parse(values[2]);
    }
}
