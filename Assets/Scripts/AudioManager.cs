using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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

    private string tempSceneName;
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        //Play("Hope");
        Debug.Log(SceneManager.GetActiveScene().name);
        tempSceneName = SceneManager.GetActiveScene().name;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Menu")
        {
            Play("Hope");
        }
        else if (scene.name == "cut1")
        {
            Play("BGM");
        }
        else if (scene.name == "Stage_1")
        {
            Play("Alone");
        }
        else if (scene.name == "cut6")
        {
            Play("GoodFriend");
        }
        else if (scene.name == "Stage_2" || scene.name == "Stage_3")
        {
            Play("Wildness");
        }
        else if (scene.name == "cut10")
        {
            Play("LastLove");
        }
    }

    private void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        scene = SceneManager.GetActiveScene();

        if (tempSceneName != scene.name)
        {
            if (scene.name == "Menu")
            {
                Stop();
                Play("Hope");
            }
            else if (scene.name == "cut1")
            {
                Stop();
                Play("BGM");
            }
            else  if (scene.name == "Stage_1")
            {
                Stop();
                Play("Alone");
            }
            else if (scene.name == "cut6")
            {
                Stop();
                Play("GoodFriend");
            }
            else if (scene.name == "Stage_2" || scene.name == "Stage_3")
            {
                Stop();
                Play("Wildness");
            }
            else if (scene.name == "cut10")
            {
                Stop();
                Play("LastLove");
            }
            tempSceneName = scene.name;
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

    public void Stop()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        } 
    }
}
