using System.Collections;
using System.Collections.Generic;
using System;
using Network;
using UnityEditor;
using UnityEngine;

public class JoinLobby : MonoBehaviour
{
    public Network_global Network;
    public int Code;
    public int Choice = 1;
    public string Name;
    
    public Dictionary<int, Player> players;
    public int Seed = -1;
    public LobbyInfos lobby;
    
    public void Send()
    {
        if (Code >= 100000)
        {
            string res = "";
            res += Name + ";";
            res += Choice + ";";
            string thisplayer = res + Network.Client.myId + ";";
            res += Code + ";";
            Network.SendString(res,IdMsg.joinLobby);
            players = new Dictionary<int, Player>();
            Player me = new Player(ClientHandle.GetValues(thisplayer));
            players.Add(me.Id, me);
        }
        else
        {
            Debug.Log("Wrong code");
            //TODO : affichier erreur
        }
    }
    

    public void GetInfos(List<string> values)
    {
        Seed = Int32.Parse(values[0]);
        lobby.choice = this.Choice;
        lobby.players = this.players;
        lobby.Name = this.name;
        lobby.isCreated = true;
        lobby.Seed = Seed;
        lobby.JoinCode = this.Code;
        lobby.lobby.AddorChangePlayer(1,this.name,this.Choice);

        List<string> temp = new List<string>();
        int count = 0;
        for(int i = 1; i < values.Count; i++)
        {
            if (count == 4)
            {
                temp.Add(values[i]);
                count = 0;
                lobby.Join(values);
                values.Clear();
            }
            else
            {
                count++;
                temp.Add(values[i]);
            }
        }
        
    }

    public void ChangeName(string name)
    {
        Name = name;
    }
    
    public void ChangeCode(string seed)
    {
        try
        {
            Code = Int32.Parse(seed);
        }
        catch (FormatException)
        {
            Debug.Log("sign other than number in seed");
            //TODO: Afficher erreur jeu
        }
    }
}
