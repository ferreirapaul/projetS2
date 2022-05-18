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
    public int choice = 1;
    public int JoinCode;
    public Network_global Network;
    public bool isCreated = false;
    public Dictionary<int, Player> players;

    public Lobby lobby;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Send()
    {
        string res = "";
        res += Name + ";";
        res += choice + ";";
        if (Seed != -1)
        {
            Seed = UnityEngine.Random.Range(0, 1000);
            res += Seed + ";";
        }

        JoinCode = UnityEngine.Random.Range(100000, 999999);
        lobby.Generate(JoinCode);
        res += JoinCode + ";";
        Network.SendString(res,IdMsg.startLobby);
        res += Network.Client.myId + ";";
        isCreated = true;
        Player p = new Player(ClientHandle.GetValues(res));
        players = new Dictionary<int, Player>();
        players.Add(p.Id, p);
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

    public void StartGame()
    {
        SceneManager.LoadScene("map");
        /*
        if (isCreated && players.Count > 2)
        {
            SceneManager.LoadScene("map");
        }*/
    }

    public void ChangeName(string name)
    {
        Name = name;
    }
    
    public void ChangeSeed(string seed)
    {
        try
        {
            Seed = Int32.Parse(seed);
        }
        catch (FormatException)
        {
            Debug.Log("sign other than number in seed");
            //TODO: Afficher erreur jeu
        }
    }
    
    public void ChangeNamePlayers(string name)
    {
        Name = name;
        
    }
}
