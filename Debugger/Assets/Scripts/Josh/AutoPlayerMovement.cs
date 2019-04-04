using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerMovement : MonoBehaviour
{
    public Transform enemy;
    public float enemyDistance;
    public float rotationDamping;
    public float chaseStartRange;
    public float moveSpeed;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").transform;

        timeBtwShots = startTimeBtwShots;
    }

    
    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindWithTag("Enemy") == null)
        {

        }

        else
        {
            enemyDistance = Vector3.Distance(enemy.position, transform.position);

            //  if(enemyDistance < 5f)
            //   {
            //      lookAtEnemy();
            //   }

            if (enemyDistance < 15f)
            {
                lookAtEnemy();
                chase();

                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }

                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }

    }

    void lookAtEnemy()
    {
        //Quaternion rotation = Quaternion.LookRotation(enemy.position - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
        transform.LookAt(enemy);
    }

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

}

