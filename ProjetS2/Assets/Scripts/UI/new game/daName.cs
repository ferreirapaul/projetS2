using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daName : MonoBehaviour
{
    public GameObject me;
    

    public void ChangeName(string name)
    {
        Debug.Log(name);
        Text P = me.GetComponent<Text>();
        Debug.Log("fojei");
        P.text = name;
    }
}
