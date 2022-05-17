using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateLobby : MonoBehaviour
{
    public static string Name;
    public static int Seed = -1;
    public static int choice = 1;
    public static int JoinCode;
    public static Network_global Network;
    public static bool isCreated = false;
    public static Dictionary<int, Player> players;

    public lobby lobby;

    public static void Send()
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
        isCreated = true;
        players = new Dictionary<int, Player>();
    }

    public static void Join(List<string> values)
    {
        Player p = new Player(values);
        players.Add(p.Id, p);
        lobby.AddorChangePlayer(players.Count, p.Name, p.Emperor);
    }

    public static void ChangeName(string name)
    {
        Name = name;
    }
    
    public static void ChangeSeed(string seed)
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

    public static void ChangeChoice()
    {
        choice += 1;
    }
    public static void ChangeNamePlayers(string name)
    {
        Name = name;
        
    }
}
