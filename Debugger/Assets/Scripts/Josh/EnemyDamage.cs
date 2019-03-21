using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private EnemyMove moveScript;
    public float Damage;
    public float Cooldown;
    private float cd;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = gameObject.GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)   // Cooldown between attacks
        {
            cd -= Time.deltaTime;
        }

        RaycastHit hit;   // Detect the hit
        if (Physics.Raycast(transform.position, Vector3.left, out hit, .6f))
        {
            if (hit.transform.tag == "Player")   // If its the player, deal damage
            {
                if (cd <= 0)
                {
                    Health hpScript = hit.transform.gameObject.GetComponent<Health>();
                    hpScript.health -= Damage;
                    cd = Cooldown;
                    Destroy(gameObject);
                }
            }

            else if (hit.transform.tag == "EndGoal")   // If its the end goal, deal damage
            {
                Health hpScript = hit.transform.gameObject.GetComponent<Health>();
                hpScript.health -= Damage;
                Destroy(gameObject);
            }

            moveScript.isBlocked = true;
        }

        else if (moveScript.isBlocked == true)
        {
            moveScript.isBlocked = false;
        }


        
    }
}
