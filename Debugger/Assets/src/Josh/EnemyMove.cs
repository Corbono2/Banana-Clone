using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float MovementSpeed;   // Holds the value of movement speed
    public bool isBlocked;

    // Update is called once per frame
    void Update()
    {
        // Make the enemy move left over time, towards the end goal
        transform.Translate(Vector3.back * MovementSpeed * Time.deltaTime);
    }
}
