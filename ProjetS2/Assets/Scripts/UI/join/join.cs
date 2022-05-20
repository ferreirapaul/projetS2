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
    public LobbyInfos lobby;

    public void PchooseCiv1()
    {
        lobby.choice = 1;
    }

    public void PchooseCiv2()
    {
        lobby.choice = 2;
    }
    public void PchooseCiv3()
    {
        lobby.choice = 3;
    }
    public void PchooseCiv4()
    {
        lobby.choice = 4;
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
}
