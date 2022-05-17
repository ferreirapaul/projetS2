using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class fornetwork 
{
    public static lobby lobby;
    public static int civP1;
    
    public static int SearchForIndex(string name)
    {
        int res = 0;
        string J1 = lobby.PanelN1.text;
        string J2 = lobby.PanelN2.text;
        string J3 = lobby.PanelN3.text;
        string J4 = lobby.PanelN4.text;
        if (name == J1)
        {
            res = 1;
        }
        if (name == J2)
        {
            res = 2;
        }
        if (name == J3)
        {
            res = 3;
        }
        if (name == J4)
        {
            res = 4;
        }
        return res;
    }
    public static void Generate(int codetojoin)
    {
        lobby.PanelAfterGenerate.SetActive(true);
        lobby.PanelBeforeGenerate.SetActive(false);
        lobby.code.text = codetojoin.ToString();
    }

    public static void AddorChangePlayer(int number, string name, int emperorcount)
    {
        lobby.AddorChangePlayer(number, name, emperorcount);
    }
    public static void P1chooseCiv1()
    {
        lobby.civP1 = 1;
    }

    public static void P1chooseCiv2()
    {
        lobby.civP1 = 2;
    }
    public static void P1chooseCiv3()
    {
        lobby.civP1 = 3;
    }
    public static void P1chooseCiv4()
    {
        lobby.civP1 = 4;
    }
}
