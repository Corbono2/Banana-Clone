using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance{get; private set;}
    public int SoundID;

    //Audio Sources
    public AudioSource backgroundSource;
    public AudioSource soundeffectSource;

    //Sounds
    public AudioClip backgroundMusic;
    public AudioClip powerUp;
    public AudioClip gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //Load sounds from Assets/Blakely/Resources/Audio/
        backgroundMusic = (AudioClip)Resources.Load<AudioClip>("Audio/background");
        powerUp = (AudioClip)Resources.Load<AudioClip>("Audio/powerup");
        gameOver = (AudioClip)Resources.Load<AudioClip>("Audio/gameover");

        backgroundSource.clip = backgroundMusic;
        backgroundSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

// public class SoundEffect : Sound 
// {

// }

// public class BackgroundMusic : Sound
// {
//     //Implement Singleton Method insuring only one instance
//     // private void Awake()
//     // {
//     //     if(Instance == null)
//     //     {
//     //         Instance = this;
//     //         DontDestroyOnLoad(gameObject);
//     //     }
//     //     else
//     //     {
//     //         Destroy(gameObject);
//     //     }
//     // }
// }