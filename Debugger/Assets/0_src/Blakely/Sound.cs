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

    public void Stop()
    {
        source.Stop();
    }

    public abstract void Play();
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

    public SoundEffect(string soundID)
    {
        this.soundID = soundID;
    }

    public SoundEffect(string soundID, float volume)
    {
        this.soundID = soundID;
        this.volume = volume;
    }

    public SoundEffect(string soundID, bool isHaptic)
    {
        this.soundID = soundID;
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

    public BackgroundMusic(string soundID)
    {
        this.soundID = soundID;
    } 

    public BackgroundMusic(string soundID, float volume)
    {
        this.soundID = soundID;
        this.volume = volume;
    } 

    public BackgroundMusic(string soundID, bool loop)
    {
        this.soundID = soundID;
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