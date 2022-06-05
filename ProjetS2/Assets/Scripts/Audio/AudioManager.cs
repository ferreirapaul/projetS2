using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake ()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);

        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

    }

    void Start()
    {
        Play("music");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds,sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " was not found!");
            return;
        }
        s.source.Play();
    }
}
