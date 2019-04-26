/*mainMenu.cs
* Joel Berain
* The script provides functionality to the main menu of the
* "Debugger" game. An example of dynamic binding can be seen
* through use of the virtual void functions found in the Button
* class. A pattern can be seen in each subclass of Button.
* Each button in the menu UI is represented in this program
* by its own class. Code reuse is demonstrated by the virtual
* function found in the Button class. This function is reused and
* modified to perform specific task dependent on which subclass
* is overriding the virtual function. 
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
    /*
    public override void buttonAction() {
        SceneManager.LoadScene("Real_MainScene");
    }*/
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
/*
class Exit: Button {
    public override void buttonAction() {
        Debug.Log("QUIT");
        Application.Quit();    
    }
}*/
public class mainMenu : MonoBehaviour {
    //Game objects
    public GameObject mainMenuUI;
    public GameObject creditsMenuUI;
    public GameObject tutorialMenuUI;

    //Button objects 
    Credits creditsAction = new Credits();
    Tutorial tutorialAction = new Tutorial();

    /*play
    INPUT: none
    OUTPUT: void
    This function creates a Play object and calls its playAction functon.
     */
    /*public void play() {
        Play playAction = new Play();
        playAction.buttonAction();
    }*/

    // Josh was here
    public void joshTest()
    {
        SceneManager.LoadScene("jt Stress Test");
    }

    /*credits
     INPUT: none
     OUTPUT: void
     This function provides the functionality for the credits
     button 
      */
    public void credits() {
        creditsAction.buttonAction();
        mainMenuUI.SetActive(false);
        creditsMenuUI.SetActive(true);
        
    }

    /*backCredits
     INPUT: none
     OUTPUT: void
     This function provides the functionality for the back button
     found in the CreditsMenuUI. 
      */
    public void backCredits() {
        creditsAction.backAction();
        creditsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    /*tutorial
     INPUT: none
     OUTPUT: void
     This function provides the functionality for the tutorial button. 
      */
    public void tutorial() {;
        tutorialAction.buttonAction();
        mainMenuUI.SetActive(false);
        tutorialMenuUI.SetActive(true);
    }


    /*backTutorial
     INPUT: none
     OUTPUT: void
     This function provides the functionality for the back button
     found in the TutorialMenuUI. 
      */
    public void backTutorial() {
        tutorialAction.backAction();
        tutorialMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    /*exit
     INPUT: none
     OUTPUT: void
     This function provides the functionality for the exit button. 
      */
    /*public void exit() {
        Exit exitAction = new Exit();
        exitAction.buttonAction();
    }*/

}
