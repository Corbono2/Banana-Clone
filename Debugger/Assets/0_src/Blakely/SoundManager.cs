using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    //public Sound[] sounds;
    //public BackgroundMusic[] sound;
    [SerializeField]
    public Sound[] background = new BackgroundMusic[1];
    //public BackgroundMusic background = new BackgroundMusic();
    
    void Awake()
    {
        // if (instance == null)
		// {
		// 	instance = this;
		// }
		// else if (instance != this)
		// {
		// 	Destroy(gameObject);
		// }

        // DontDestroyOnLoad(gameObject);

        if(instance != null)
        {
            Debug.LogError("SoundManager: More than one SoundManager in Scene");
        }
        else
        {
            instance = this;
        }

    }

    void Start()
    {
        for(int i =  0; i < background.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + background[i].soundID);
            background[i].SetSource(_go.AddComponent<AudioSource>());

        }
        
        PlaySound("Theme");
    }

    public void PlaySound(string name)
    {
        for(int i = 0; i < background.Length; i++)
        {
            if(background[i].soundID == name)
            {
                background[i].Play(); 
                return;
            }
        }

        Debug.LogWarning("SoundManager: Requested sound was not found");
    }

}
