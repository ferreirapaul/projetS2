using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadSettings()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNewGame()
    {
        SceneManager.LoadScene(2);
    }
}
