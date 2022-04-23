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
    public Network_global Network;
    
    
    void Start()
    {
        GameObject.Instantiate(Network);
    }

    public void Send()
    {
        string res = "";
        res += "Name:" + Name;
        res += "Choice:" + choice;
        if (Seed != -1)
        {
            res += "Seed:" + Seed;
        }
        Network.SendMessage(res,IdMsg.startLobby);
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
