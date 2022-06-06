using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOW : MonoBehaviour
{
    public GameObject f;

    public void setFOW(bool b)
    {
        f.SetActive(b);
    }
}
