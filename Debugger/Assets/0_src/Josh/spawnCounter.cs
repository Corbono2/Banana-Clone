using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class spawnCounter : MonoBehaviour
{
    Text txt;
    private int enemiesSpawned = 0;
    private int endGoalHealthExpected = 0;
    public static int enemyDeathCounter = 0;
    public static int endGoalHealth = 0;
    public static float endGoalHealthReal = 0;
    private float endGoalStart = 0;
    protected StreamWriter writer;
    private string testOutputFile;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        string dateandtime = System.DateTime.Now.ToString("yyyy MMM dd  HH.mm.ss");
        testOutputFile = "Assets/0_tst/Josh/stresstest" + "_" + dateandtime + ".txt";
        var file = File.Open(testOutputFile, FileMode.OpenOrCreate, FileAccess.Write);
        writer = new StreamWriter(file);
        Health hpscript = GameObject.FindGameObjectWithTag("EndGoal").GetComponent<Health>();
        endGoalStart = hpscript.health;
        endGoalHealthReal = endGoalStart;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        endGoalHealthExpected = enemyDeathCounter * EnemyDamage.Damage;
        txt.text = "Running Josh's Stress Test\n" + "Enemies on Field: " + enemies.Length + "  " + "Enemies Dead: " + enemyDeathCounter + "  " + "Damage Dealt: " + endGoalHealth + "  " + "Expected: " + endGoalHealthExpected + "  " + "End Goal Health: " + endGoalHealthReal;
        
        if (GameObject.FindGameObjectWithTag("EndGoal") == null)
        {
            txt.text = "Test Complete. Loading Josh's Boundary Test 1. . .";
            var dateandtime = System.DateTime.Now.ToString("HH:mm:ss");

            if (endGoalHealth == endGoalStart)
            {
                writer.WriteLine(dateandtime + " " + "Enemies Dead: " + enemyDeathCounter + "  " + "Damage Dealt: " + endGoalHealth + "  " + "Expected: " + endGoalHealthExpected + "  " + "End Goal Health at End: " + endGoalHealthReal + " " + "PASS");
       
            }

            else
            {
                writer.WriteLine(dateandtime + " " + "Enemies Dead: " + enemyDeathCounter + "  " + "Damage Dealt: " + endGoalHealth + "  " + "Expected: " + endGoalHealthExpected + "  " + "End Goal Health at End: " + endGoalHealthReal + " " + "FAIL");
             
            }

            writer.Close();

            System.Threading.Thread.Sleep(3000);
            SceneManager.LoadScene("jt boundary1");
        }
    }

}
