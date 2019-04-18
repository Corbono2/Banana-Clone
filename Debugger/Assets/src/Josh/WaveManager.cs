using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemy;   // Get enemy prefab to spawn
    public float cooldown = 3f;   // Cooldown time between spawns
    public Transform[] spawnPoints;   // An array of the spawn points this enemy can spawn from

    // Start is called before the first frame update
    void Start()
    {
        // Call the Spawn function after a delay of the cooldown and continue to call after the same amount of time
        InvokeRepeating("Spawn", cooldown, cooldown);
    }

    void Spawn()
    {
        Health endGoalHealth = GameObject.FindGameObjectWithTag("EndGoal").GetComponent<Health>();  // Reference to end goal health
        // If the end goal has no health left...
        if (endGoalHealth.health <= 0f)
        {
            // ... exit the function.
            return;
        }

        // If it's still alive...
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
