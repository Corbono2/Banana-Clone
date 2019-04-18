using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_FPVMovement : MonoBehaviour
{
  private float sensitivity = 2f;

  void Update () {
      var c = GameObject.FindGameObjectWithTag("Turret").transform;
      c.Rotate(0, Input.GetAxis("Mouse X")* sensitivity, 0);
      c.Rotate(0, 0, Input.GetAxis("Mouse Y")* sensitivity/2);
      if (Input.GetMouseButtonDown(0)) {
        Cursor.lockState = CursorLockMode.Locked;
      }
  }
}
