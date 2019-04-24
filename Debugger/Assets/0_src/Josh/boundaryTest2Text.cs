using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class boundaryTest2Text : MonoBehaviour
{
    Text txt;
    public float endGoalHealth;

    //Timer variables before continuing to next scene
    private float timer = 0;
    private float timerMax = 0;


    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Health hpscript = GameObject.FindGameObjectWithTag("EndGoal").GetComponent<Health>();
        endGoalHealth = hpscript.health;
        txt.text = "Josh's Test to see if Game Over can be achieved\n" + "End Goal HP: " + endGoalHealth;

        if (endGoalHealth == 0)
        {
            txt.text = "If you're reading this, the test failed. . . Back to main menu in 3 seconds. . .";
            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("mainMenu");
        }
    }

    private bool Waited(float seconds)
    {
        timerMax = seconds;

        timer += Time.deltaTime;

        if (timer >= timerMax)
        {
            return true; //max reached - waited x - seconds
        }

        return false;
    }
}
