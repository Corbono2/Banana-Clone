using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    [SerializeField]
    BackgroundMusic music;
    [SerializeField]
    SoundEffect[] soundFx;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
            Debug.LogError("SoundManager: More than one SoundManager in Scene");
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameObject mainSound = new GameObject(music.soundID);
        music.SetSource(mainSound.AddComponent<AudioSource>());

        for(int i = 0; i < soundFx.Length; i++)
        {
            GameObject effect = new GameObject(soundFx[i].soundID);
            soundFx[i].SetSource(effect.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string sound)
    {
        if(sound == music.soundID)
        {
            music.Play();
        }
        else
        {
            Debug.LogWarning("SoundManager: Requested sound was not found");
        }

        for(int i = 0; i < soundFx.Length; i++)
        {
            if(name == soundFx[i].soundID)
            {
                soundFx[i].Play();
                return;
            }
            else
            {
                Debug.LogWarning("SoundManager: Requested sound was not found");   
            }
        }
    }
}
