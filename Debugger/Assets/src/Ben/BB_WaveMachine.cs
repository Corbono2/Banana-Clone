using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_WaveMachine : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public float spawnTime = 3f;
    public GameObject target;

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
      Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
