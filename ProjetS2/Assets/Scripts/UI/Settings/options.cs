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
    

    

    private void Awake() 
    {
        SliderChange();
        KeyBinding.SetActive(visible);
        Panel.SetActive(visible);
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
        }

    }

    public void SetResolution()
    {
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(640, 360, true);
                break;

            case 1:
                Screen.SetResolution(1600, 900, true);
                break;

            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }

    public void SliderChange()
    {
        audiosource.volume = slider.value;
        TxtVolume.text = "Volume " + (audiosource.volume * 100).ToString("00") + "%";
    }
    public void LoadStart()
    {
        SceneManager.LoadScene(0);
    }
    
}
