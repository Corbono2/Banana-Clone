using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public bool isEndGoal;   // Check if its the end goal that died
    //public bool isStructure;   // Check if its a structure that died
    public bool isPlayer;   // Check if its the player that died
    // Default case would be that the enemy died

    private Health hpScript;   // To store health scripts of objects
    private Money moneyScript;   // To store money script
    private bool isTestScene;   // Checks if we are currently running a test

    // Start is called before the first frame update
    void Start()
    {
        hpScript = gameObject.GetComponent<Health>();   // Get health script of object

        Scene currentScene = SceneManager.GetActiveScene(); // Create temporary reference to current scene
        string sceneName = currentScene.name;

        if (sceneName == "Real_MainScene" || sceneName == "jt boundary2")
        {
            isTestScene = false;
        }

        else
        {
            isTestScene = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hpScript.health <= 0)
        {
            if (isEndGoal)   // Handles death of end goal
            {
                if (!isTestScene)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("mainMenu");
                }

                else
                {
                    Destroy(gameObject);
                }
            }

           // if (isStructure)   // Handles death of structure
          //  {
          //      Destroy(gameObject);   // Remove structure after its destroyed, game can still continue
           // }

            if (isPlayer)   // Handles death of player
            {
                Destroy(gameObject);

                FindObjectOfType<SoundManager>().StopSound("Theme");
                FindObjectOfType<SoundManager>().PlaySound("Death");
                // Reminder: Trigger game over? Or continue game with remaining structures
            }

            else   // Handles death of enemy
            {
                // Enemy destroyed
                Destroy(gameObject);
                // Give resource to player
                //moneyScript += 10F; // Reminder: come back and update this value later
            }
        }
    }
}
