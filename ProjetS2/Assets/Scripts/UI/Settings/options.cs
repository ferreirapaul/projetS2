using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public GameObject Panel;
    bool visible = false;

    public Dropdown DResolution;

    public AudioSource audiosource;
    public Slider slider;
    public Text TxtVolume;

    public GameObject KeyBinding;

    private settinginstart settinginstart;

    public InputField Forward;
    public InputField Left;
    public InputField Back;
    public InputField Right;


    private void Awake() 
    {
        
        settinginstart = FindObjectOfType<settinginstart>();
        Forward.text = settinginstart.movement[0];
        Left.text = settinginstart.movement[1];
        Back.text = settinginstart.movement[2];
        Right.text = settinginstart.movement[3];
        slider.value = settinginstart.volume;
        audiosource.volume =settinginstart.volume;
        TxtVolume.text = "Volume " + (audiosource.volume * 100).ToString("00") + "%";
        SliderChange();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
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

    public void SetResolution()
    {
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                break;

            case 1:
                Screen.SetResolution(1600, 900, true);
                break;

            case 2:
                Screen.SetResolution(640, 360, true);
                break;
        }
    }

    public void SliderChange()
    {
        audiosource.volume = slider.value;
        TxtVolume.text = "Volume " + (audiosource.volume * 100).ToString("00") + "%";
        settinginstart.volume = audiosource.volume;

    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
    
}
