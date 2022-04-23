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
    // Start is called before the first frame update
    void Start()
    {
        PanelAfterGenerate.SetActive(false);
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Generate()
    {
        PanelAfterGenerate.SetActive(true);
        PanelBeforeGenerate.SetActive(false);
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(1);
    }
}
    
