using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent myAgent;
    Transform target;

    // Start is called before the first frame update
    void Start() {
      myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
      target = GameObject.FindGameObjectWithTag("Player").transform;
      // Transform armiture = GameObject.FindGameObjectWithTag("armiture").transform;
      // armiture.GetComponent<Animation>().Play("Spider_Armiture|walk_ani_vor");
    }

    // Update is called once per frame
    void Update()
    {
      myAgent.SetDestination(target.position);
    }
}
