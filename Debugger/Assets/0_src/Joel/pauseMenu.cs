using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool pauseIt = false;
    public GameObject pauseMenuUI;
    
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

    public void resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        pauseIt = false;

    }

    void pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        pauseIt = true;
    }

    public void tutorial() {
        Debug.Log("Tutorial");
    }

    public void endGame() {
        Debug.Log("EndGame");
    }
}
