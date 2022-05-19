using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class join : MonoBehaviour
{
    private int civP1 = 1;
    private string name = "";

    public InputField PanelN;

    public JoinLobby lobby;
    

    public void PchooseCiv1()
    {
        lobby.Choice = 1;
    }

    public void PchooseCiv2()
    {
        lobby.Choice = 2;
    }
    public void PchooseCiv3()
    {
        lobby.Choice = 3;
    }
    public void PchooseCiv4()
    {
        lobby.Choice = 4;
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
}
