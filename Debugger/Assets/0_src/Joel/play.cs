using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
	//new play game buttom
    public void PlayGame() {
    	//Just to make sure its working
    	Debug.Log("Play Game sucess");
        SceneManager.LoadScene("Real_MainScene");
        //Application.LoadLevel("Real_MainScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }
     // Start is called before the first frame update
     //reload the timescale, so that the component combine with timescale can be intialize
     //before load into new player game scene.
     void Start()
     {
     	Time.timeScale = 1;
     }
}
