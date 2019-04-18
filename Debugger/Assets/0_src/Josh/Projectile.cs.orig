using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform enemy;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        target = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            destroyProjectile();
        }
    }

    void OnTriggerEnter3D(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            destroyProjectile();
        }
    }

    void destroyProjectile()
    {
        Destroy(gameObject);
    }
}
