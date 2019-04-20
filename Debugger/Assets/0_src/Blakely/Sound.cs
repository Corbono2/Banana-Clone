using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

//Abstract class for template pattern
public abstract class Sound
{
    //Sound Properties
    public string soundID;
    public float volume;
    public AudioClip clip;
    [HideInInspector] public AudioSource source; //Hides the AudioSource in inspector but still serialized

    //Set each sound with a AudioSource to play them - static method
    public void SetSource(AudioSource source)
    {
        this.source = source;
        this.source.clip = clip;
    }

    //Stop sound playback - static method
    public void Stop()
    {
        source.Stop();
    }

    //Template method to play sound
    public abstract void Play();
}

//Concrete class SoundEffect - Manages game soundeffects
//System.Serializable allows embedding of a class in the inspector
[System.Serializable]
class SoundEffect : Sound
{
    //SoundEffect properties
    public bool isHaptic;

    //SoundEffect Methods
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

    //Override abstract template - allows haptic response
    public override void Play()
    {
        source.Play();

        if(isHaptic == true)
        {
            // Handheld.Vibrate(); <- commented out so the project can build and run ~Ben
        }
    }
}

//Concrete class BackgroundMusic - Manages game music
//System.Serializable allows embedding of a class in the inspector
[System.Serializable]
class BackgroundMusic : Sound
{
    //BackgroundMusic properties
    public bool loop;


    //BackgroundMusic methods
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

    //Override abstract template - allows looping
    public override void Play()
    {
        source.Play();

        if(loop == true)
        {
            source.loop = this.loop;
        }
    }
}
