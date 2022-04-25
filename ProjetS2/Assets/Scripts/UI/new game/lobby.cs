using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobby : MonoBehaviour
{
    public GameObject PanelAfterGenerate;
    public GameObject PanelBeforeGenerate;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;

    public InputField code;

    public InputField PanelN2;
    public InputField PanelN3;
    public InputField PanelN4;

    public GameObject PanelC2;
    public GameObject PanelC3;
    public GameObject PanelC4;

    private List<(InputField, GameObject)> AllPanel;

    
    private CreateLobby allplayers;
    private int count;
    
    // Start is called before the first frame update
    void Start()
    {
        PanelAfterGenerate.SetActive(false);
    Panel2.SetActive(false);
    Panel3.SetActive(false);
    Panel4.SetActive(false);

    AllPanel = new List<(InputField, GameObject)>();
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

    public void RemovePlayer()
    {
        /*for (int i = 0; i < length; i++)
        {
            
        }*/
       
    }
    public void AddPlayer()
    {
        switch (allplayers.players.Count)
        {
            case 1:
                break;
            case 2:
                Panel2.SetActive(true);
                AllPanel[0].Item1.text = allplayers.players[count].Name;
                AllPanel[0].Item2.GetComponentInChildren<Text>().text = allplayers.players[count].Emperor.ToString();
                break;
            case 3:
                Panel3.SetActive(true);
                AllPanel[1].Item1.text = allplayers.players[count].Name;
                AllPanel[1].Item2.GetComponentInChildren<Text>().text = allplayers.players[count].Emperor.ToString();
                break;
            default:
                Panel4.SetActive(true);
                AllPanel[2].Item1.text = allplayers.players[count].Name;
                AllPanel[2].Item2.GetComponentInChildren<Text>().text = allplayers.players[count].Emperor.ToString();
                break;
        }
        count++;
    }

    

    public void Generate()
    {
        PanelAfterGenerate.SetActive(true);
        PanelBeforeGenerate.SetActive(false);
        code.text = UnityEngine.Random.Range(100000, 999999).ToString();
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(4);
    }
}
    
