using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    // Start is called before the first frame update
    void Start()
    {
        Panel2.SetActive(false);
        Panel3.SetActive(false);
        Panel4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    
