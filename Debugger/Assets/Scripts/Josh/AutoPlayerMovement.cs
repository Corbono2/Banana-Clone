using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlayerMovement : MonoBehaviour
{
    public Transform player;
    public float playerDistance;
    public float rotationDamping;
    public float chaseStartRange;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);

        if(playerDistance < 15f)
        {
            lookAtPlayer();
        }

        if(playerDistance < 12f)
        {

        }
    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

}

