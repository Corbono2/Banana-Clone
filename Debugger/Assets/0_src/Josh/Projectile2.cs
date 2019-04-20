using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Projectile2 : Projectile
{

    /* Project Type 2 - Ice bullet (Working name)
     * Slows the enemy if collision detected
     * Overrides the default virtual function it derives from Projectile
     */

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            (collision.gameObject).GetComponent<NavMeshAgent>().speed = 0;    

            gameObject.SetActive(false);
        }
    }
}
