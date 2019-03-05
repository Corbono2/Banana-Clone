using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    private Animator animator;
    private float timePassed = 0f;
    private float keyDelay = 1f;
    public ProjectileScript myProjectile;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontalVal =  Input.GetAxis("Vertical");
       bool shoot = Input.GetKey("space");
       timePassed += Time.deltaTime;
       if(shoot && timePassed >= keyDelay){
           timePassed = 0f;
            myProjectile = Instantiate(myProjectile, animator.bodyPosition, Quaternion.identity);
             myProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 150);
           //Instantiate(myProjectile);
       }
     if(horizontalVal == 0){
animator.SetBool("move",false);
     }else{
         if(horizontalVal>0 ){
             animator.SetBool("move",true);
         }
     }
    }
}
