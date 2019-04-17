using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public Sound[] sounds;

    
    void Awake()
    {
        if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

        DontDestroyOnLoad(gameObject);


        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }

    }

    public void Play(string soundID)
    {
        Sound s = Array.Find(sounds, item => item.soundID == soundID);
        s.source.Play();   
    }

}
