using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Modified by Josh for stress testing

public class BB_EnemyController_TargetEG : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent myAgent;
    Transform target;
    public Animator myAnimator;
    private bool hasArrived = false;

    // Start is called before the first frame update
    void OnEnable() {
      myAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
      target = GameObject.FindGameObjectWithTag("EndGoal").transform;   // Line modified by Josh
      myAnimator = GetComponent<Animator>();
      myAnimator.Play("quin@move_forward"); //Start the moving animation
     
    }

    // Update is called once per frame
    void Update()
    {
      if(hasArrived)
        {
            SceneManager.LoadScene(sceneName: "mainMenu"); //***************************************************Tried Brute Force Load Scene Here*******************
            return; //If the enemy has arrived it can stop moving
        }

      //If there is no target, no movement will occur so we can use the idle animation
      if(target == null) {
        myAnimator.Play("quin@idle");//*************************************FLAG*****************************************, Not working as intended
            return;
      }

      //Set the target for the enemy to move towards
      myAgent.SetDestination(target.position); //*************************************FLAG*****************************************

      // Check if we've reached the destination
        if (!myAgent.pathPending) {
          if (myAgent.remainingDistance <= myAgent.stoppingDistance) {
              if (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f) {
                //Play the attacking animation
                attackRight();
                hasArrived = true;
              }
              else {
                //Make sure the enemy is using the moving animation
                //myAnimator.Play("qiun@move_forward");
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

    IEnumerator wait() {
      die();
      myAgent.isStopped = true;
      yield return new WaitForSecondsRealtime(2);
      // gameObject.SetActive(false);
      // yeet the enemies instead of banishing them to the shadow realm
      gameObject.transform.position = new Vector3(10,-10,16);
    }

}
