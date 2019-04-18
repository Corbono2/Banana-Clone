using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public static int Damage = 20;   // Change this value for damage output
    public float Cooldown;
    private float cd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)   // Cooldown between attacks
        {
            cd -= Time.deltaTime;
        }

        RaycastHit hit;   // Detect the hit
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, .6f))
        {
            if (hit.transform.tag == "Player")   // If its the player, deal damage
            {
                if (cd <= 0)
                {
                    Health hpScript = hit.transform.gameObject.GetComponent<Health>();
                    hpScript.health -= Damage;
                    cd = Cooldown;
                    Destroy(gameObject);
                    spawnCounter.enemyDeathCounter += 1;
                }
            }

            else if (hit.transform.tag == "EndGoal")   // If its the end goal, deal damage
            {
                Health hpScript = hit.transform.gameObject.GetComponent<Health>();
                spawnCounter.endGoalHealthReal -= Damage;
                hpScript.health -= Damage;
                spawnCounter.endGoalHealth += Damage;
                spawnCounter.enemyDeathCounter += 1;
                Destroy(gameObject);
                
            }
        }
        
    }
}
