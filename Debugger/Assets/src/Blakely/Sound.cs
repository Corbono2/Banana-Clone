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
}
