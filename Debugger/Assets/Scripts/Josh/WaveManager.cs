using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int NumEnemies;  // Store number of enemies to be spawned
    public GameObject[] Enemies;   // Get enemy object
    public float Cooldown;   // Store cooldown before wave starts
    private float cd;

    // Start is called before the first frame update
    void Start()
    {
        cd = Cooldown * 2;   // Cooldown value
    }

    // Update is called once per frame
    void Update()
    {
        if(cd > 0)
        {
            cd -= Time.deltaTime;   // If cooldown is active, decrease cooldown timer
        }

        else   // Cooldown over, start wave
        {
            cd = Cooldown;
            Vector3 pos = new Vector3(3, 1, Random.Range(-3, 4));   // Set up to spawn enemy in random lane
            int index = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[index], pos, Quaternion.Euler(0,90,0));   // Get the enemy object
        }
    }
}
