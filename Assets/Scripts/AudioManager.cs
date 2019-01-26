using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance = null;

    void Awake()
    {
        //Singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this; //In this case, it runs when you play game first time only.
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Play("BG_Music");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Play("BGM");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        s.source.Play();
    }
}
