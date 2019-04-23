using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Shooting script that implements object pooling pattern
//Attach to object being fired from
public class Shoot : MonoBehaviour
{
    float bulletSpeed = 500;    //Force of bullet fired
    public GameObject bullet1;   //Allows selection of gameobject in inspector
    public GameObject bullet2;   //Allows selection of gameobject in inspector

    public int pooledAmount;    //Allows change of pooled value in inspector
    List<GameObject> bulletList;    //List to hold bullets
    List<GameObject> bulletList2;    //List to hold bullets

    void Start()
    {
        //Instantiate bullets on start
        bulletList = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet1);
            objBullet.SetActive(false);
            bulletList.Add(objBullet);
        }
        
        //Instantiate bullets on start
        bulletList2 = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet2);
            objBullet.SetActive(false);
            bulletList2.Add(objBullet);
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

    //If bullet currently inactive in hierarchy, fire it
    void Fire2()
    {

        for (int i = 0; i < bulletList2.Count; i++)
        {
            if (!bulletList2[i].activeInHierarchy) 
            {
                bulletList2[i].transform.position = transform.position;
                bulletList2[i].transform.rotation = transform.rotation;
                bulletList2[i].SetActive(true);
                Rigidbody tempRigidBodyBullet2 = bulletList2[i].GetComponent<Rigidbody>();
                tempRigidBodyBullet2.AddForce(tempRigidBodyBullet2.transform.forward * bulletSpeed);
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

        if (Input.GetButtonDown("Fire2"))
        {
            Fire2();
        }


    }
}
