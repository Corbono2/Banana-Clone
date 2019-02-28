using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_monkeyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      float forwardSpeed = Input.GetAxis("Vertical");
      float sideWaysSpeed = Input.GetAxis("Horizontal");
      CharacterController cc = GetComponent<CharacterController>();

      Vector3 speed = new Vector3(sideWaysSpeed, 0, forwardSpeed);
      cc.Move(speed);
    }
}
