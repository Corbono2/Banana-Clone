using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Singleton pattern to ensure only 1 Game manager is created
public class PersistentGameManager : MonoBehaviour
{
    public static PersistentGameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}