using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_WaveMachine : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTime = 3f;
    public int numEnemies = 1;
    public GameObject target;
    // GameObject EnemyPooler;

    // Start is called before the first frame update
    void Start()
    {
      BeginSpawning();
    }

    void BeginSpawning() {
      InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn() {
      if(target == null) {
        return;
      }

      int spawnPointIndex = Random.Range(0, spawnPoints.Length);
      GameObject newEnemy = EnemyPooler.SharedInstance.GetPooledObject();
      if (newEnemy != null) {
        newEnemy.transform.position = spawnPoints[spawnPointIndex].position;
        newEnemy.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        newEnemy.SetActive(true);
        numEnemies++;
      }

    }
}
