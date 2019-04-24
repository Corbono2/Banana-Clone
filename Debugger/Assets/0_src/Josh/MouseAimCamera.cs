using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script sets a camera that follows the character in the third person
 * It makes it possible to control the character on the horizontal plane through the mouse
 * Basically copy and pasted from https://code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230
 */

public class MouseAimCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
