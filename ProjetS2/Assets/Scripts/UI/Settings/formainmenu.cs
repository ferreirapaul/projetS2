using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class formainmenu : MonoBehaviour
{
    public GameObject Panel;

    public Dropdown DResolution;

    public GameObject audiosource;
    public AudioSource audio;
    public Slider slider;
    public Text TxtVolume;

    public GameObject KeyBinding;
    public Toggle local;
    public Toggle online;
    private settinginstart settinginstart;

    public InputField Forward;
    public InputField Left;
    public InputField Back;
    public InputField Right;


    private void Awake()
    {
        audiosource = FindObjectOfType<AudioManager>().gameObject;
        audio = audiosource.GetComponent<AudioSource>();
        settinginstart = FindObjectOfType<settinginstart>();
        Forward.text = settinginstart.movement[0];
        Left.text = settinginstart.movement[1];
        Back.text = settinginstart.movement[2];
        Right.text = settinginstart.movement[3];
        slider.value = settinginstart.volume;
        TxtVolume.text = "Volume " + (settinginstart.volume * 100).ToString("00") + "%";
        SliderChange();
    }
    public void DisplayKeyBinding()
    {
        GameObject KeyBind = Instantiate(KeyBinding);
        KeyBind.transform.SetParent(Panel.transform);

         KeyBind.SetActive(false);
    }

    public void SetResolution()
    {
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                settinginstart.resolutions = (1920, 1080);
                break;

            case 1:
                Screen.SetResolution(1600, 900, true);
                settinginstart.resolutions = (1600, 900);
                break;

            case 2:
                Screen.SetResolution(640, 360, true);
                settinginstart.resolutions = (640, 360);
                break;
        }
    }
    public void Changemovement(int index)
    {
        switch (index)
        {
            case 0:
                settinginstart.movement[0] = Forward.text;
                break;
            case 1:
                settinginstart.movement[1] = Left.text;
                break;
            case 2:
                settinginstart.movement[2] = Back.text;
                break;
            case 3:
                settinginstart.movement[3] = Right.text;
                break;
            default:
                break;
        }
        
    }

    public void SliderChange()
    {
        audio.volume = slider.value;
        TxtVolume.text = "Volume " + (slider.value * 100).ToString("00") + "%";
        settinginstart.volume = audio.volume;
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
    public void IpLocal()
    {
        Toggle local1 = local.GetComponent<Toggle>();
        Toggle online1= online.GetComponent<Toggle>();
        Debug.Log(local);
        online1.isOn = false;
        settinginstart.ip = "127.0.0.1";

    }
    public void IpOnline()
    {
        Toggle local1 = local.GetComponent<Toggle>();
        Toggle online1 = online.GetComponent<Toggle>();
        Debug.Log(local);
        local1.isOn = false;
        settinginstart.ip = "epirum.fr";

    }
}
