using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class Button {
    public virtual void buttonAction() {
        Debug.Log("Button Action");
    }
    public virtual void backAction() {
        Debug.Log("Back it up!");
    }
}

class Play: Button {
    public override void buttonAction() {
        SceneManager.LoadScene("Real_MainScene");
    }
}

class Credits: Button {
 
    public override void buttonAction() {
        Debug.Log("Credits");
    }
}

class Tutorial: Button {
    public override void buttonAction() {
        Debug.Log("Tutorial");
    }
}

public class mainMenu : MonoBehaviour
{
    
    public GameObject mainMenuUI;
    public GameObject creditsMenuUI;
    public GameObject tutorialMenuUI;
            
    Credits creditsAction = new Credits();
    Tutorial tutorialAction = new Tutorial();
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
        creditsAction.buttonAction();
        mainMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
        
    }

    public void backCredits() {
        creditsAction.backAction();
        creditsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void tutorial() {;
        tutorialAction.buttonAction();
        mainMenuUI.SetActive(false);
        tutorialMenuUI.SetActive(true);
    }

    public void backTutorial() {
        tutorialAction.backAction();
        tutorialMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
    public void exit() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
