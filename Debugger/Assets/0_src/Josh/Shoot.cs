using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Shooting script that implements object pooling pattern
//Attach to object being fired from
public class Shoot : MonoBehaviour
{
    bool specialBulletActive;

    float bulletSpeed = 500;    //Force of bullet fired
    public GameObject bullet1;   //Allows selection of gameobject in inspector
    public GameObject bullet2;   //Allows selection of gameobject in inspector
    public GameObject specialBullet; // Adds the special bullet easter egg - Benjamin (Dream Team)

    public int pooledAmount;    //Allows change of pooled value in inspector
    List<GameObject> bulletList;    //List to hold bullets
    List<GameObject> bulletList2;    //List to hold bullets
    List<GameObject> specialBulletList;    //List to hold bullets

    void Start()
    {
        specialBulletActive = false;

        //Instantiate bullets on start
        bulletList = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(bullet1);
            objBullet.name = "bullet";
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

        //Instantiate bullets on start
        specialBulletList = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject objBullet = (GameObject)Instantiate(specialBullet);
            objBullet.SetActive(false);
            specialBulletList.Add(objBullet);
        }
    }

    //If bullet currently inactive in hierarchy, fire it
    void Fire()
    {
        if (!specialBulletActive) {
            for (int i = 0; i < bulletList.Count; i++)
            {

                if (!bulletList[i].activeInHierarchy)
                {
                    bulletList[i].transform.position = transform.position;
                    bulletList[i].transform.rotation = transform.rotation;
                    bulletList[i].SetActive(true);
                    Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();// *****************If Destroyed this is where the error is maybe?
                    tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
                    break;
                }

            }
        }
        else
        {
            for (int i = 0; i < specialBulletList.Count; i++)
            {

                if (!specialBulletList[i].activeInHierarchy)
                {
                    specialBulletList[i].transform.position = transform.position;
                    specialBulletList[i].transform.rotation = transform.rotation;
                    specialBulletList[i].SetActive(true);
                    Rigidbody tempRigidBodyBullet = specialBulletList[i].GetComponent<Rigidbody>();// *****************If Destroyed this is where the error is maybe?
                    tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
                    break;
                }

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            specialBulletActive = true;
        }
    }
}
