using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daName : MonoBehaviour
{
    public Text txt;
    
    public void ChangeName(string name)
    {
        txt.text = name;
    }
}
