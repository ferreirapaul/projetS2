using System.Collections;
using System.Collections.Generic;
using System;
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

    public GameObject civP2;
    public GameObject civP3;
    public GameObject civP4;

    public InputField code;

    public InputField NameP1;
    public daName NameP2;
    public Text NameP3;
    public Text NameP4;

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
        Debug.Log("Fuck");
        Panel.SetActive(true);
        Debug.Log("Yes Yes Yes");
        civP1.GetComponentInChildren<Text>().text = "emperor number " + civ1;
        code.text = codetojoin.ToString();
    }

    public void AddPlayer(int player, string name, int emperor)
    {
        Debug.Log("shit");
        switch(player)
        {
            case 2:

                Debug.Log("shit1");
                NameP2.ChangeName(name);
                civP2.GetComponentInChildren<Text>().text = "emperor number " + emperor;
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
