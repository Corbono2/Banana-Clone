using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void play() {
<<<<<<< HEAD
        SceneManager.LoadScene("game");
=======
        SceneManager.LoadScene("Real_MainScene");
    }

    // Josh was here
    public void joshTest()
    {
        SceneManager.LoadScene("jt Stress Test");
>>>>>>> 9d9933dbcdc103af02597321c71252dba36eaa0f
    }

    public void exit() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
