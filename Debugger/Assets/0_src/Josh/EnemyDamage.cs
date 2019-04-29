using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public static int Damage = 20;   // Change this value for damage output
    public float Cooldown = 3;
    private float cd = 0;
    private BB_EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<BB_EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cd > 0)   // Cooldown between attacks
        {
            cd -= Time.deltaTime;
            return;
        }

        RaycastHit hit;   // Detect the hit
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1.5f))
        {
            if (hit.transform.tag == "Player")   // If its the player, deal damage
            {
                Health hpScript = hit.transform.gameObject.GetComponent<Health>();
                hpScript.health -= Damage;
                Destroy(gameObject);
                spawnCounter.enemyDeathCounter += 1;
            }

            else if (hit.transform.tag == "EndGoal")   // If its the end goal, deal damage
            {
                Debug.Log("Hit Goal");
                enemyController.attackRight();
                Health hpScript = hit.transform.gameObject.GetComponent<Health>();
                spawnCounter.endGoalHealthReal -= Damage;
                hpScript.health -= Damage;
                spawnCounter.endGoalHealth += Damage;
                spawnCounter.enemyDeathCounter += 1;
                
            }
            cd = Cooldown;
        }
        
    }
}
