using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void play() {
        SceneManager.LoadScene("game");
    }

    public void exit() {
        Debug.Log("QUIT");
        //Application.Quit();
    }
}
