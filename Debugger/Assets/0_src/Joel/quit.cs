using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    //new quit game buttom setup
    public void QuitGame () {
    	//Just to make sure its working
    	Debug.Log("End Game sucess");
        Application.Quit ();
 }
}
