using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    private Animator animator;
    private float timePassed = 0f;
    private float keyDelay = 0.2f;
    public ProjectileScript myProjectile;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       float verticalVal =  Input.GetAxis("Vertical");
       float horizontalVal = Input.GetAxis("Horizontal");
        /*bool shoot = Input.GetKey("space");
        timePassed += Time.deltaTime;
        if(shoot && timePassed >= keyDelay){
            timePassed = 0f;
             myProjectile = Instantiate(myProjectile, animator.bodyPosition, Quaternion.identity);
              myProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 150);
            //Instantiate(myProjectile);
        }*/

        if (verticalVal == 0){
        animator.SetBool("moveForward",false);
        animator.SetBool("moveBackward",false);
        Debug.Log("Setting values");
        }else{
            if(verticalVal>0 ){
                Debug.Log("Setting values forward");
                animator.SetBool("moveForward",true);
                animator.SetBool("moveBackward",false);
             }else if(verticalVal<0){
                Debug.Log("Setting values backwards");
                animator.SetBool("moveBackward",true);
                animator.SetBool("moveForward",false);
             }
         }
         if(horizontalVal != 0){
            float horizontal = horizontalVal * 3;
            gameObject.transform.Rotate(0, horizontal, 0);
         }
     }
    }

