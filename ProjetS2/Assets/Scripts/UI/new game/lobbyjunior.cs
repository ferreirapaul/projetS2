using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lobbyjunior : MonoBehaviour
{
    public LobbyInfos lobbyinf;
    public InputField Seed;
    public GameObject Panel;
    public GameObject before;

    public InputField code;

    public InputField NameP1Base;
    public daName NameP1;
    public GameObject P1;
    public daName NameP2;
    public GameObject P2;
    public daName NameP3;
    public GameObject P3;
    public daName NameP4;
    public GameObject P4;

    public void Awake()
    {
        lobbyinf = FindObjectOfType<LobbyInfos>();
    }

    public void Update()
    {
        P1.SetActive(false);
        P1.SetActive(true);
        P2.SetActive(false);
        P2.SetActive(true);
        P3.SetActive(false);
        P3.SetActive(true);
        P4.SetActive(false);
        P4.SetActive(true);
    }

    public void Send()
    {
        lobbyinf.SendCreate();
    }

    public void PchooseCiv1()
    {
        lobbyinf.choice = 1;
    }

    public void PchooseCiv2()
    {
        lobbyinf.choice = 2;
    }
    public void PchooseCiv3()
    {
        lobbyinf.choice = 3;
    }
    public void PchooseCiv4()
    {
        lobbyinf.choice = 4;
    }

    public void ChangeName()
    {
        lobbyinf.Name = NameP1Base.text;
    }

    public void ChangeSeed()
    {
        try
        {
            lobbyinf.Seed = Int32.Parse(Seed.text);
        }
        catch(FormatException)
        {
            Debug.Log("sign other than number in the seed");
        }
    }   

    public void Generate(int codetojoin)
    {
        /*
        before.SetActive(false);
        Panel.SetActive(true);
        code.text = codetojoin.ToString();*/
    }

    public void AddPlayer(int player, string name)
    {
        switch(player)
        {
            case 2:
                NameP2.ChangeName(name);
                break;
            case 3:
                NameP3.ChangeName(name);
                break;
            default:
                NameP4.ChangeName(name);
                break;
        }
    }

    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(4);
    }

}
