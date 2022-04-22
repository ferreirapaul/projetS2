using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using UnityEngine;

public class CreateLobby : MonoBehaviour
{
    public string Name;
    public int Seed = -1;
    public Network_global Network;
    
    
    void Start()
    {
        GameObject.Instantiate(Network);
        string res = "";
        res += "Name:" + Name;
        if (Seed != -1)
        {
            res += "Seed:" + Seed;
        }
        Network.SendMessage(res,IdMsg.startLobby);
    }
    
    
    
}
