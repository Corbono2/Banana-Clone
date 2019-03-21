using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public static Sound gameMusic;
    public static Sound instance = null;

    public AudioSource backgroundSource;

    //public int SoundID;
    public AudioClip backgroundMusic;

    // Start is called before the first frame update
    public void Start()
    {
        //Load background music from Assets/Blakely/Resources/Audio/background.mp3
        backgroundMusic = (AudioClip)Resources.Load<AudioClip>("Audio/background");

        backgroundSource.clip = backgroundMusic;
        backgroundSource.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
