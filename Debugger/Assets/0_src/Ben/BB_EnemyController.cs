using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent myNavmeshAgent;
    Transform target;
    public Animator myAnimator;
    private bool hasArrived = false;

    // Start is called before the first frame update
    void OnEnable() {
      //Set up navemesh agent
      myNavmeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
      //Set the target for the enemy to move towards
      target = GameObject.FindGameObjectWithTag("FPVCam").transform;
      myAnimator = GetComponent<Animator>();
      myAnimator.Play("quin@move_forward"); //Start the moving animation
    }

    // Update is called once per frame
    void Update()
    {
      if(hasArrived) {
        return; //If the enemy has arrived, it doesn't need to be moving
      }

      if(target == null) {
        //If there's no target yet, we can use the idling animation
        myAnimator.Play("quin@idle");
        return;
      }

      myNavmeshAgent.SetDestination(target.position);
      // Check if we've reached the destination
      if (!myNavmeshAgent.pathPending) {
          if (myNavmeshAgent.remainingDistance <= myNavmeshAgent.stoppingDistance) {
              if (!myNavmeshAgent.hasPath || myNavmeshAgent.velocity.sqrMagnitude == 0f) {
                attackRight(); //Play the attack animation
                hasArrived = true;
              }
              else {
                //Make sure the moving animation is being played
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

    //Handles when a bullet collides with the enemy
    void OnCollisionEnter(Collision col) {
      //Start the death sequence
      StartCoroutine(deathSequence());
      //Destroy the bullet
      Destroy(col.gameObject);
    }


    //This function handles when the enemy should be killed
    IEnumerator deathSequence() {
      die(); //Play the die animation
      //Stop the navmesh agent
      myNavmeshAgent.isStopped = true;
      //Wait a couple seconds while the enemy dies and lies dead
      yield return new WaitForSecondsRealtime(2);
      //Deactivate the enemy so it's ready to be reused in the future
      gameObject.SetActive(false);
    }
}
