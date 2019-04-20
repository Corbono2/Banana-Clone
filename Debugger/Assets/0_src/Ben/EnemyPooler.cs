using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
  public static EnemyPooler SharedInstance;
  public List<GameObject> pooledObjects;
  public GameObject objectToPool;
  public int amountToPool = 50;


  void Awake() {
    SharedInstance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    //Create a list of objects
    pooledObjects = new List<GameObject>();

    //Pool the appropriate amount of objects and make sure they are inactive
    for (int i = 0; i < amountToPool; i++) {
      GameObject obj = (GameObject)Instantiate(objectToPool);
      obj.SetActive(false);
      pooledObjects.Add(obj);
    }

  }

  public GameObject GetPooledObject() {
    for (int i = 0; i < pooledObjects.Count; i++) {
      if (!pooledObjects[i].activeInHierarchy) {
        return pooledObjects[i];
      }
    }
    return null;
  }


  // Update is called once per frame
  void Update()
  {

  }
}
