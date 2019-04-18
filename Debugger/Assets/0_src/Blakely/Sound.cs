using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class Sound 
{
    public string soundID;
    public float volume;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;

    public void SetSource(AudioSource s)
    {
        source = s;
        source.clip = clip;
    }

    public virtual void Play()
    {
        source.Play();
    }
}

[System.Serializable]
public class SoundEffect : Sound
{
    public bool hapticResponse;
    //private AudioSource source2;

    public override void Play()
    {
        source.Play();

        if(hapticResponse == true)
        {
            //Handheld.Vibrate();
        }
    }
}

[System.Serializable]
public class BackgroundMusic : Sound
{
    public bool loop;
}