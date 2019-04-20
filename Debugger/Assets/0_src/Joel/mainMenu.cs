/*mainMenu.cs
* Joel Berain
* The script provides functionality to the main menu of the
* "Debugger" game. An example of dynamic binding can be seen
* through use of the virtual void functions found in the Button
* class.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Button class holds the virtual functions
class Button {

    /*buttonAction
    INPUT: none
    OUTPUT: void
    This function is a virtual function and can be overridden by methods
    with the same call type found in subclasses. This is an example
    of polymorphism and dynamic or late binding. The type of object
    will determine which one of thes type of methods gets called.
     */
    public virtual void buttonAction() {
        Debug.Log("Button Action");
    }
    /*backAction
    INPUT: none
    OUTPUT: void
    This is a virtual function for the functionality of the back buttons.
     */
    public virtual void backAction() {
        Debug.Log("Back it up!");
    }
}

//Subclass of Button
class Play: Button {

    /*buttonAction
    INPUT: none 
    OUTPUT: void
    This is an override function for the play button action. When
    pressed, the scene for the gameplay will be loaded.
     */
    public override void buttonAction() {
        SceneManager.LoadScene("Real_MainScene");
    }
}

//Subclass of Button
class Credits: Button {
 
    /*buttonAction
     INPUT: none
     OUTPUT: void
     This is an override function for the credits button. When pressed
     its functionality will be handled in a function found in the
     main class and this function will print an indicator message
     in the Debug console. 
      */
    public override void buttonAction() {
        Debug.Log("Credits");
    }
}

//Sublcass of Button
class Tutorial: Button {
    /*buttonAction
     INPUT: none
     OUTPUT: void
     This is an override function for the tutorials button. When pressed
     it's functionality will be handled in a class found in the main
     class and this function will print an indicator message in the 
     Debug console.
      */
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
