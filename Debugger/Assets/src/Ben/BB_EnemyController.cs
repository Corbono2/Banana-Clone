using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent myAgent;
    Transform target;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start() {
      myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
      target = GameObject.FindGameObjectWithTag("Player").transform;
      myAnimator = GetComponent<Animator>();
      myAnimator.Play("qiun@move_forward");
    }

    // Update is called once per frame
    void Update()
    {
      myAgent.SetDestination(target.position);
      // Check if we've reached the destination
      if (!myAgent.pathPending) {
          if (myAgent.remainingDistance <= myAgent.stoppingDistance) {
              if (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f) {
                myAnimator.Play("quin@attack_right");
              }
          }
      }
    }
}
