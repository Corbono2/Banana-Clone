using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent myAgent;
    Transform target;
    public Animator myAnimator;
    private bool hasArrived = false;

    // Start is called before the first frame update
    void OnEnable() {
      myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
      target = GameObject.FindGameObjectWithTag("Player").transform;
      myAnimator = GetComponent<Animator>();
      myAnimator.Play("quin@move_forward");
    }

    // Update is called once per frame
    void Update()
    {
      if(hasArrived) {
        return;
      }

      if(target == null) {
        myAnimator.Play("quin@idle");
        return;
      }

      myAgent.SetDestination(target.position);
      // Check if we've reached the destination
      if (!myAgent.pathPending) {
          if (myAgent.remainingDistance <= myAgent.stoppingDistance) {
              if (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f) {
                attackRight();
                hasArrived = true;
              }
              else {
                myAnimator.Play("qiun@move_forward");
              }
          }
      }
    }

    void eat() {
      myAnimator.Play("quin@eat");
    }

    void attackLeft() {
      myAnimator.Play("quin@attack_left");
    }

    void attackRight() {
      myAnimator.Play("quin@attack_right");
    }

    void die() {
      myAnimator.Play("quin@death_blowed");
    }

    //void OnCollisionEnter(Collision col) {
    //  StartCoroutine(wait());
    //  Destroy(col.gameObject);
    //}

    IEnumerator wait() {
      die();
      myAgent.isStopped = true;
      yield return new WaitForSecondsRealtime(2);
      gameObject.SetActive(false);
    }

    // void OnAnimatorMove() {
    //   myAgent.speed = (myAnimator.deltaPosition / Time.deltaTime).magnitude;
    // }
}
