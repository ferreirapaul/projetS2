using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daName : MonoBehaviour
{
    public GameObject me;
    private Text t;
    
    public void Start()
    {
        t = me.GetComponent<Text>();
    }
    public void ChangeName(string name)
    {
        Debug.Log(name);
        t.text = name;
    }
    public void ChangeCiv(string emperor)
    {
        t.text = "emperor number " + emperor;
    }
}
