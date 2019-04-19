using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

public abstract class Sound
{
    public string soundID;
    public float volume;
    public AudioClip clip;

    //[HideInInspector]
    public AudioSource source;

    public void SetSource(AudioSource source)
    {
        this.source = source;
        this.source.clip = clip;
    }

    public abstract void Play();
    //public abstract void SetVolume();
}

[System.Serializable]
class SoundEffect : Sound
{
    public bool isHaptic;

    public SoundEffect(string soundID, float volume, bool isHaptic)
    {
        this.soundID = soundID;
        this.volume = volume;
        this.isHaptic = isHaptic;
    }

    public override void Play()
    {
        source.Play();

        if(isHaptic == true)
        {
            Handheld.Vibrate();
        }
    }
}

[System.Serializable]
class BackgroundMusic : Sound
{
    public bool loop;

    public BackgroundMusic(string soundID, float volume, bool loop)
    {
        this.soundID = soundID;
        this.volume = volume;
        this.loop = loop;
    } 

    public override void Play()
    {
        source.Play();

        if(loop == true)
        {
            source.loop = this.loop;
        }
    }
}