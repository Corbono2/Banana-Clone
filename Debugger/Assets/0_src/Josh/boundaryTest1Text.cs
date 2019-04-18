using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class boundaryTest1Text : MonoBehaviour
{
    Text txt;
    private int enemiesLostCounter; // Holds the value of enemies that fall off map or disappear


    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        txt.text = "Josh's Test to see if enemies stay within the map\n" + "Enemies on Field: " + enemies.Length + " Enemies Off Map: " + enemiesLostCounter;

        if (enemies.Length < enemies.Length)
        {
            enemiesLostCounter++;
        }

        if (enemies.Length == 1000)
        {
            txt.text = "Test Concluded. Enemies Off Map: " + enemiesLostCounter + "/1000.\nMoving on to Boundary Test 2. . .";
            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("jt boundary2");
        }
    }

}
