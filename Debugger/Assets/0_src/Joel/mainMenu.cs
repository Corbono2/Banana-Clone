using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class Button {
    public GameObject mainMenuUI;
    public GameObject creditMenuUI;

    public virtual void buttonAction() {
        Debug.Log("Button Action");
    }
}

class Play: Button {
    public override void buttonAction() {
        SceneManager.LoadScene("Real_MainScene");
    }
}

class Credits: Button {
 
    public override void buttonAction() {
        Debug.Log("Credits Menu");
    }
}


public class mainMenu : MonoBehaviour
{
    
    public GameObject mainMenuUI;
    public GameObject creditsMenuUI;

    public void play() {
        Play playAction = new Play();
        playAction.buttonAction();
    }

    // Josh was here
    public void joshTest()
    {
        SceneManager.LoadScene("jt Stress Test");
    }

    public void credits() {
        Credits creditsAction = new Credits();
        creditsAction.buttonAction();
        mainMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
        
    }
    public void exit() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
