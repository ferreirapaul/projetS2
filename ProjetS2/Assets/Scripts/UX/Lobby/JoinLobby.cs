using System.Collections;
using System.Collections.Generic;
using System;
using Network;
using UnityEngine;

public class JoinLobby : MonoBehaviour
{
    public static Network_global Network;
    public static int Code;
    public static int Choice = 1;
    public static string Name;
    
    public static Dictionary<int, Player> players;
    public static int Seed = -1;
    public static lobby lobby;
    
    public void Send()
    {
        if (Code >= 100000)
        {
            string res = "";
            res += Name + ";";
            res += Choice + ";";
            res += Code + ";";
            Network.SendString(res,IdMsg.joinLobby);
        }
        else
        {
            Debug.Log("Wrong code");
            //TODO : affichier erreur
        }
    }
    
    public static void Join(List<string> values)
    {
        Player p = new Player(values);
        players.Add(p.Id, p);
        lobby.AddorChangePlayer(players.Count, p.Name, p.Emperor);
    }

    public static void GetInfos(List<string> values)
    {
        Seed = Int32.Parse(values[0]);
        List<string> temp = new List<string>();
        int count = 0;
        for(int i = 1; i < values.Count; i++)
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
    
    public static void ChangeChoice()
    {
        Choice += 1;
    }
    
    public static void ChangeName(string name)
    {
        Name = name;
    }
    
    public static void ChangeCode(string seed)
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
