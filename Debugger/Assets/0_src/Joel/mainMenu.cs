using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void play() {
      //There was a merge conflict so I commented out the following line. ~Ben
        // SceneManager.LoadScene("game");
        SceneManager.LoadScene("Real_MainScene");
    }

    // Josh was here
    public void joshTest()
    {
        SceneManager.LoadScene("jt Stress Test");
    }

    public void exit() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
