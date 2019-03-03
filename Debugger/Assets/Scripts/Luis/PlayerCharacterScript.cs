using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontalVal =  Input.GetAxis("Horizontal");
     if(horizontalVal == 0){
animator.SetBool("move",false);
     }else{
         if(horizontalVal>0 ){
             animator.SetBool("move",true);
         }
     }
    }
}
