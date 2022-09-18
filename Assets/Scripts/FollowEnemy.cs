using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;


    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;


     float enemyHealth= 2f;

    private void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }

        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

        }

    }
     /// <summary>
     /// ////////////////////////////////////////////////////////////
     /// </summary>
     /// <param name="collision"></param>
     /// 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Debug.Log("X");
            enemyHealth -= 1f;
            if(enemyHealth < 0)
            {
                Destroy(collision.gameObject);
            }
            
        }
    }
}
