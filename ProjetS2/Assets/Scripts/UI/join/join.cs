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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeName(string change)
    {
        name = change;
    }

    public void PchooseCiv1()
    {
        civP1 = 1;
    }

    public void PchooseCiv2()
    {
        civP1 = 2;
    }
    public void PchooseCiv3()
    {
        civP1 = 3;
    }
    public void PchooseCiv4()
    {
        civP1 = 4;
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
}
