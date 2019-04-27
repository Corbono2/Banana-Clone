using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_WaveMachine : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTime = 3f;
    public GameObject target;
    public EnemyPooler SharedInstance;

    // Start is called before the first frame update
    void Start()
    {
      beginSpawning();
    }

    //Calls the spawn() function per the spawnTime frequency
    void beginSpawning() {
      InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    //Spawns and enemy at one of the spawnPoints -- chosen randomly
    public void Spawn() {
      //Get a random index
      int spawnPointIndex = Random.Range(0, spawnPoints.Length);

      //Get an enemy from the object pool
      GameObject newEnemy = EnemyPooler.SharedInstance.GetPooledObject();

      if (newEnemy != null) {
        //Set the position of the new enemy to the random spawn point
        newEnemy.transform.position = spawnPoints[spawnPointIndex].position;
        newEnemy.transform.rotation = spawnPoints[spawnPointIndex].rotation;

        //Activate the enemy
        newEnemy.SetActive(true);
        Debug.Log("Spawned enemy");

      }
    }
    public void Respawn()
      {
        //Get a random index
      int spawnPointIndex = Random.Range(0, spawnPoints.Length);

      //Get an enemy from the object pool
      GameObject Enemy = EnemyPooler.SharedInstance.GetPooledObject();

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate (Enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
      }
}
