using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_EnemyAI : MonoBehaviour
{
    Transform tr_player;
    float f_rotSpeed = 3.0f, f_moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start() {
      tr_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
      //Turn towards the player
      transform.rotation = Quaternion.Slerp(transform.rotation,
                                            Quaternion.LookRotation(tr_player.position - transform.position),
                                            f_rotSpeed * Time.deltaTime);

      //Move towards the player
      transform.position += transform.forward*f_moveSpeed*Time.deltaTime;
    }
}
