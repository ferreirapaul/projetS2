using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LobbyInfos : MonoBehaviour
{
    public string Name;
    public int Seed = -1;
    public int Code;
    public int choice = 1;
    public Network_global Network;
    public bool isCreated = false;
    public Dictionary<int, Player> players;

    public lobby lobby;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void SendCreate()
    {
        string res = "";
        res += Name + ";";
        res += choice + ";";
        if (Seed == -1)
        {
            Seed = UnityEngine.Random.Range(0, 1000);
            res += Seed + ";";
        }

        Code = UnityEngine.Random.Range(100000, 999999);
        res += Code + ";";
        Network.SendString(res,IdMsg.startLobby);
        res += Network.Client.myId + ";";
        isCreated = true;
        Player p = new Player(ClientHandle.GetValues(res));
        lobby.Generate(Code,p);
        players = new Dictionary<int, Player>();
        players.Add(p.Id, p);
    }
    
    public void SendJoin()
    {
        if (Code >= 100000)
        {
            string res = "";
            res += Name + ";";
            res += choice + ";";
            string thisplayer = res + Network.Client.myId + ";";
            res += Code + ";";
            Network.SendString(res,IdMsg.joinLobby);
            players = new Dictionary<int, Player>();
            Player me = new Player(ClientHandle.GetValues(thisplayer));
            players.Add(me.Id, me);
            this.isCreated = true;
        }
        else
        {
            Debug.Log("Wrong code");
            //TODO : affichier erreur
        }
    }

    public void Join(List<string> values)
    {
        if (isCreated)
        {
            Player p = new Player(values);
            players.Add(p.Id, p);
            lobby.AddorChangePlayer(players.Count, p.Name, p.Emperor);
        }
    }
    
    public void GetInfos(List<string> values)
    {
        List<string> temp = new List<string>();
        SceneManager.LoadScene("New Game");
        lobby.Generate(Code,players[Network.Client.myId]);
        
        int count = 0;
        for(int i = 1; i < temp.Count; i++)
        {
            if (count == 4)
            {
                temp.Add(values[i]);
                count = 0;
                Join(values);
                values.Clear();
            }
            else
            {
                count++;
                temp.Add(values[i]);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("map");
        /*
        if (isCreated && players.Count > 2)
        {
            SceneManager.LoadScene("map");
        }*/
    }

    public void ChangeCode(string codestr)
    {
        try
        {
            this.Code = Int32.Parse(codestr);
        }
        catch (FormatException)
        {
            Debug.Log("sign other than number in seed");
            //TODO: Afficher erreur jeu
        }
    }
    
}
