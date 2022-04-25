using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateLobby : MonoBehaviour
{
    public string Name;
    public int Seed = -1;
    public int choice = 1;
    public int JoinCode;
    public Network_global Network;
    public bool isCreated = false;
    public Dictionary<int, Player> players;

    public void Send()
    {
        string res = "";
        res += Name + ";";
        res += choice + ";";
        if (Seed != -1)
        {
            this.Seed = UnityEngine.Random.Range(0, 1000);
            res += this.Seed + ";";
        }

        this.JoinCode = UnityEngine.Random.Range(100000, 999999);
        res += this.JoinCode + ";";
        Network.SendString(res,IdMsg.startLobby);
        isCreated = true;
        players = new Dictionary<int, Player>();
    }

    public void Join(List<string> values)
    {
        Player p = new Player(values);
        players.Add(p.Id, p);
        //TODO : UPDATE UI
    }

    public void ChangeName(string name)
    {
        this.Name = name;
    }
    
    public void ChangeSeed(int seed)
    {
        this.Seed = seed;
    }

    public void ChangeChoice()
    {
        this.choice += 1;
    }
}
