using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Lobby : MonoBehaviour
{
    public GameObject PanelAfterGenerate;
    public GameObject PanelBeforeGenerate;

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;

    public InputField code;

    public InputField PanelN1;
    public InputField PanelN2;
    public InputField PanelN3;
    public InputField PanelN4;

    public GameObject PanelC1;
    public GameObject PanelC2;
    public GameObject PanelC3;
    public GameObject PanelC4;

    public InputField Seed;

    private List<(InputField, GameObject)> AllPanel;
    public LobbyInfos Lobbyinf;



    // Start is called before the first frame update
    void Start()
    {
        PanelAfterGenerate.SetActive(false);

        AllPanel = new List<(InputField, GameObject)>();
        AllPanel.Add((PanelN1, PanelC1));
        AllPanel.Add((PanelN2, PanelC2));
        AllPanel.Add((PanelN3, PanelC3));
        AllPanel.Add((PanelN4, PanelC4));
    }
    
    
    public void AddorChangePlayer(int number,string name,int emperorcount)
    {
        if (number==2)
        {
            AllPanel[1].Item1.text = name;
            AllPanel[1].Item2.GetComponentInChildren<Text>().text = "emperor number" + emperorcount;
        }
        else if (number==3)
        {
            Panel3.SetActive(true);
            AllPanel[2].Item1.text = name;
            AllPanel[2].Item2.GetComponentInChildren<Text>().text = "emperor number" + emperorcount;
        }
        else if (number==4)
        {
            Panel4.SetActive(true);
            AllPanel[3].Item1.text = name;
            AllPanel[3].Item2.GetComponentInChildren<Text>().text = "emperor number" + emperorcount;
        }

    }
    
    public void Generate(int codetojoin, Player p)
    {
        PanelAfterGenerate.SetActive(true);
        PanelBeforeGenerate.SetActive(false);
        code.text = codetojoin.ToString();
        AllPanel[0].Item1.text = p.Name;
        AllPanel[0].Item2.GetComponentInChildren<Text>().text = "emperor number" + p.Emperor;
    }
    
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(4);
    }

    public void ChangeName()
    {
        Lobbyinf.Name = AllPanel[0].Item1.text;
    }

    public void ChangeSeed()
    {
        try
        {
            Lobbyinf.Seed = Int32.Parse(Seed.text);
        }
        catch (FormatException)
        {
            Debug.Log("sign other than number in seed");
            //TODO: Afficher erreur jeu
        }
    }
    
    public void P1chooseCiv1()
    {
        Lobbyinf.choice = 1;
    }

    public void P1chooseCiv2()
    {
        Lobbyinf.choice = 2;
    }
    public void P1chooseCiv3()
    {
        Lobbyinf.choice = 3;
    }
    public void P1chooseCiv4()
    {
        Lobbyinf.choice = 3;
    }
}