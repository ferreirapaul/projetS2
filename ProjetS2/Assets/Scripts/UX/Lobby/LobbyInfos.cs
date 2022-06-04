using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LobbyInfos : MonoBehaviour
{
    public string Name;
    public int Seed = -1;
    public int Code;
    public int choice = 1;
    public bool isGetInfo = false;
    private bool ChangeScene = false;
    public List<string> getinfosValues;
    public Network_global Network;
    public bool isCreated = false;
    public Dictionary<int, Player> players;
    public Player me;

    public lobbyjunior lobby;

    public void Start()
    {
        DontDestroyOnLoad(this); 
    }

    public void Update()
    {
        if (isGetInfo)
        {
            GetInfos(getinfosValues);
        }
        if (lobby is null && SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            lobby = FindObjectOfType<lobbyjunior>();
        }

        if (ChangeScene)
        {
            SceneManager.LoadScene(4);
            ChangeScene = false;
        }
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
        lobby.Generate(Code);
        me = new Player(ClientHandle.GetValues(res), true);
        players = new Dictionary<int, Player>();
        players.Add(me.Id, me);
        
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
            me = new Player(ClientHandle.GetValues(thisplayer), false);
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
            Player p = new Player(values, false);
            players.Add(p.Id, p);
            lobby.AddPlayer(players.Count, p.Name);
        }
    }
    
    public void GetInfos(List<string> values)
    {
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(2))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            List<string> temp = new List<string>();
            if (!(lobby is null))
            {
                isGetInfo = false;
                lobby.Generate(Code,this.Name);
                this.Seed = Int32.Parse(values[0]);
                int count = 1;
                for (int i = 1; i < values.Count; i++)
                {
                    if (count == 3)
                    {
                        temp.Add(values[i]);
                        count = 1;
                        Join(temp);
                        temp.Clear();
                    }
                    else
                    {
                        count++;
                        temp.Add(values[i]);
                    }
                }
            }
        }
    }

    public void StartGameHost()
    {
        if (isCreated && players.Count >= 2 && me.isHost)
        {
            Network.SendString("start", IdMsg.launchGame);
            StartGame();
        }
    }

    public void StartGame()
    {
        ChangeScene = true;
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
