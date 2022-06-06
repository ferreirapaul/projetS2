using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationBox : MonoBehaviour
{
    public Text t;

    public void ChangeText(string val)
    {
        this.gameObject.SetActive(true);
        this.t.text = val;
        this.t.gameObject.SetActive(false);
        this.t.gameObject.SetActive(true);
    }

}
