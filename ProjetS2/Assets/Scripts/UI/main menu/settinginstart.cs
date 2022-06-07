using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settinginstart : MonoBehaviour
{
   public string ip = "192.168.1.180";
    public List<string> movement = new List<string>{"z","q","s","d"};
    public (int,int) resolutions=(1920,1080);
    public float volume = 1;
    public void Start()
    {
        DontDestroyOnLoad(this);
    }
}