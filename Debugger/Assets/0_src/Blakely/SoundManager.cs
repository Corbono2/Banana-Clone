using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    //SoundManager properties
    //Static instance of sound Manager allows it to be accessed by any other script
    public static SoundManager instance = null;
    [SerializeField] BackgroundMusic music;
    [SerializeField] SoundEffect[] soundFx;

    //SoundManager methods
    //Reuse from Unity 2D Roguelike tutorial of GameManager Singleton pattern
    void Awake()
    {
        //Check if instance already exists
        if(instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if(instance != this)
        {
            //Then destroy this. This enforces a singleton pattern.
            Destroy(gameObject);
            Debug.LogError("SoundManager: More than one SoundManager in Scene");
        }
        //Sets this to not be destroyed when reloading done
        DontDestroyOnLoad(gameObject);
    }

    //Intialize all sounds with a Game object and AudioSource
    void Start()
    {
        //Background music initialization
        GameObject mainSound = new GameObject(music.soundID);
        music.SetSource(mainSound.AddComponent<AudioSource>());

        //Sound Effects initialization
        for(int i = 0; i < soundFx.Length; i++)
        {
            GameObject effect = new GameObject(soundFx[i].soundID);
            soundFx[i].SetSource(effect.AddComponent<AudioSource>());
        }

        PlaySound("Theme");
    }

    //Play requested sound
    public void PlaySound(string sound)
    {
        //Check given sound name matches and soundIDs
        for(int i = 0; i < soundFx.Length; i++)
        {
            if(sound == soundFx[i].soundID)
            {
                soundFx[i].Play();
                return;
            }
        }

        if(sound == music.soundID)
        {
            music.Play();
        }
        else
        {
            //Throw warning if sound wasn't found
            Debug.LogWarning("SoundManager: Requested sound was not found");
        }
    }

    //Stop sound
    public void StopSound(string sound)
    {
        //Check given sound name matches and soundIDs
        for(int i = 0; i < soundFx.Length; i++)
        {
            if(sound == soundFx[i].soundID)
            {
                soundFx[i].Stop();
                return;
            }
        }
        Debug.LogWarning("SoundManager: Requested sound was not found");

        if(sound == music.soundID)
        {
            music.Stop();
        }
        else
        {
            //Throw warning if sound wasn't found
            Debug.LogWarning("SoundManager: Requested sound was not found");
        }
    }
}
