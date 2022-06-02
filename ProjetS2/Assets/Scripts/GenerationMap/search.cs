using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class search : MonoBehaviour
{
    public GameObject button;
    public GenMapScript map;

    void Start()
    {
      

        Debug.Log("start");
        map = FindObjectOfType<GenMapScript>();
        Debug.Log("start2");
    }

    
    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("OnPointerClick called.");
        Debug.Log("button pressed");
        map.SelectCity((int)button.transform.localPosition.x,(int)button.transform.localPosition.y);
    }

    public void function()
    {
        Debug.Log("button pressed");
        map.SelectCity((int)button.transform.localPosition.x,(int)button.transform.localPosition.y);
    }
}
