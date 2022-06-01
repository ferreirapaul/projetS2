using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player
{
    public string Name;
    public int Id;
    public bool isHost;
    public int Emperor;

    public Player(List<string> values, bool host)
    {
        this.Name = values[0];
        this.Emperor = Int32.Parse(values[1]);
        this.Id = Int32.Parse(values[2]);
        this.isHost = host;
    }
}
