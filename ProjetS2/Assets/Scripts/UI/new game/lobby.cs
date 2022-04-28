using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobby : MonoBehaviour
{
    public GameObject PanelAfterGenerate;
    public GameObject PanelBeforeGenerate;
   
    private int civP1 = 0;

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

    
    private CreateLobby allplayers;
    private int count;
    public CreateLobby Createlobby;

    // Start is called before the first frame update
    void Start()
    {
    PanelAfterGenerate.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);

    AllPanel = new List<(InputField, GameObject)>();
    AllPanel.Add((PanelN1, PanelC1));
    AllPanel.Add((PanelN2, PanelC2));
    AllPanel.Add((PanelN3, PanelC3));
    AllPanel.Add((PanelN4, PanelC4));



        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (count <= allplayers.players.Count)
        {
            AddPlayer();
        }
        */
    }
    public void Continue()
    {
        if (Seed.text!=""&&PanelN1.text!=""&& civP1 != 0)
        {
            PanelAfterGenerate.SetActive(true);
            PanelBeforeGenerate.SetActive(false);
            Createlobby.Send();
        }

    }

    public void RemovePlayer()
    {
        /*for (int i = 0; i < length; i++)
        {
            
        }*/
       
    }
    public void AddorChangePlayer(int number,string name,int emperorcount)
    {
        switch (number)
        {
            case 1:
                AllPanel[0].Item1.text = name;
                AllPanel[0].Item2.GetComponentInChildren<Text>().text = "emperor number" + emperorcount.ToString();
                break;
            case 2:
                Panel2.SetActive(true);
                AllPanel[1].Item1.text = name;
                AllPanel[1].Item2.GetComponentInChildren<Text>().text = "emperor number" + emperorcount.ToString();
                break;
            case 3:
                Panel3.SetActive(true);
                AllPanel[2].Item1.text = name;
                AllPanel[2].Item2.GetComponentInChildren<Text>().text = "emperor number" + emperorcount.ToString();
                break;
            case 4:
                Panel4.SetActive(true);
                AllPanel[3].Item1.text = name;
                AllPanel[3].Item2.GetComponentInChildren<Text>().text = "emperor number" + emperorcount.ToString();
                break;
            default:
                break;
        }
        
    }

    public int SearchForIndex(string name)
    {
        int res = 0;
        string J1 = AllPanel[0].Item1.text;
        string J2 = AllPanel[1].Item1.text;
        string J3 = AllPanel[2].Item1.text;
        string J4 = AllPanel[3].Item1.text;
        if (name==J1)
        {
            res = 1;
        }
        if (name==J2)
        {
            res = 2;
        }
        if (name==J3)
        {
            res = 3;
        }
        if (name==J4)
        {
            res = 4;
        }
        return res;
    }

    

    public void Generate(int codetojoin)
    {
        PanelAfterGenerate.SetActive(true);
        PanelBeforeGenerate.SetActive(false);
        code.text = codetojoin.ToString();
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(4);
    }
    public void P1chooseCiv1()
    {
        civP1 = 1;
    }

    public void P1chooseCiv2()
    {
        civP1 = 2;
    }
}