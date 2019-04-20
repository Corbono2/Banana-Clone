using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Shooting script that implements object pooling pattern
//Attach to object being fired from
public class Shoot : MonoBehaviour
{
    float bulletSpeed = 500;    //Force of bullet fired
    public GameObject bullet;   //Allows selection of gameobject in inspector

    public int pooledAmount;    //Allows change of pooled value in inspector
    List<GameObject> bulletList;    //List to hold bullets

    void Start()
    {
        //Instantiate bullets on start
        bulletList = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
    }

    //If bullet currently inactive in hierarchy, fire it
    void Fire()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].transform.position = transform.position;
                bulletList[i].transform.rotation = transform.rotation;
                bulletList[i].SetActive(true);
                Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
                break;
            }
        }
    }

    //Shoot if left click/space inputted 
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
}
