using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach script to bullet prefab for object pooling

public class Projectile : MonoBehaviour
{
    public float Damage;

    public void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hideBullet", 2.0f); // Sets bullet to inactive after 2 seconds without collison
    }

    void hideBullet()
    {
        gameObject.SetActive(false);    //Sets bullet to inactive
    }

    public void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        CancelInvoke();
    }

    // Destroys the enemy if collision detected
    // Set to virtual for default fire
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);    //Comment/Uncomment this for kill in 1 hit

            gameObject.SetActive(false);
        }
    }

    //Reminder to make some sort of damage system
    /*private void Update()
    {
        RaycastHit hit;   // Detect the hit
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, .6f))
        {
            if (hit.transform.tag == "Enemy")   // If its the enemy, deal damage
            {
                {
                    Health hpScript = hit.transform.gameObject.GetComponent<Health>();
                    hpScript.health -= Damage;
                }
            }
        }
    }*/

}
      
       

