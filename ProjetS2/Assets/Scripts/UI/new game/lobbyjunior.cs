using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lobbyjunior : MonoBehaviour
{
    private int civ1 = 1;


    public LobbyInfos lobbyinf;
    public InputField Seed;
    public GameObject Panel;
    public GameObject civP1;

    public daName civP2;
    public GameObject civP3;
    public GameObject civP4;

    public InputField code;

    public InputField NameP1;
    public daName NameP2;
    public GameObject T;

    public Text NameP3;
    public Text NameP4;
    private List<string> allnames = new List<string>() { "Name", "Name", "Name" };
    private List<string> allciv = new List<string>(){"0", "0", "0"};

    public void Update()
    {
        //NameP2.ChangeName(allnames[0]);
        //civP2.ChangeCiv(allciv[0]);
        T.SetActive(false);
        T.SetActive(true);
    }

    public void PchooseCiv1()
    {
        civ1 = 1;
    }

    public void PchooseCiv2()
    {
        civ1 = 2;
    }
    public void PchooseCiv3()
    {
        civ1 = 3;
    }
    public void PchooseCiv4()
    {
        civ1 = 4;
    }

    public void ChangeName()
    {
        lobbyinf.Name = NameP1.text;
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
        Panel.SetActive(true);
        civP1.GetComponentInChildren<Text>().text = "emperor number " + civ1;
        code.text = codetojoin.ToString();
    }

    public void AddPlayer(int player, string name, int emperor)
    {
        allnames[player - 2] = name;
        allciv[player - 2] = emperor.ToString();
        switch(player)
        {
            case 2:
                Debug.Log("2");
                NameP2.ChangeName(name);
                civP2.ChangeName(emperor.ToString());
                break;
            case 3:
                NameP3.enabled = false;
                NameP3.text = name;
                NameP3.enabled = true;
                civP3.GetComponentInChildren<Text>().text = "emperor number " + emperor;
                break;
            default:
                NameP4.enabled = false;
                NameP4.text = name;
                NameP4.enabled = true;
                civP4.GetComponentInChildren<Text>().text = "emperor number " + emperor;
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