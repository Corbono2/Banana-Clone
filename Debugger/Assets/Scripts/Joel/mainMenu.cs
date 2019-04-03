using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void play() {
        SceneManager.LoadScene("MainScene");
    }

    public void exit() {
        Debug.Log("QUIT");
        //Application.Quit();
    }
}
