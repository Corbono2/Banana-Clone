/*pauseMenu.cs
* Joel Berain
* This script creates the functionality of the pause menu for 
* the game "Debugger".
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    //Static variable
    public static bool pauseIt = false;

    //Game obeject for PauseMenu UI
    public GameObject pauseMenuUI;
    
    /*Update
    * INTPUT: none
    * OUTPUT: void
    * This function continuosuly checks to see if the player has
    * pressed the key "P" to either pause or resume gameplay. 
    */
    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            if(pauseIt) {
                resume();
            }
            else {
                pause();
            }
        }
    }

    /*resume
    * INPUT: none
    * OUTPUT: void
    * This function resumes gameplay when called.
    */
    public void resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        pauseIt = false;

    }

    /*pause
    * INPUT: none
    * OUTPUT: void
    * This function pauses gameplay when called.
    */
    void pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        pauseIt = true;
    }

    /*tutorial
    * INPUT: none
    * OUTPUT: void
    * This function prints an indicator message in the Debug log
    * when the tutorial button is seleected. The functionality
    * is done in Unity. 
    */
    public void tutorial() {
        Debug.Log("Tutorial");
    }

    /*endGame()
    * INPUT: none
    * OUTPUT: void
    * This function .
    */
    public void endGame() {
        SceneManager.LoadScene("mainMenu");
        Debug.Log("EndGame");
    }
}
