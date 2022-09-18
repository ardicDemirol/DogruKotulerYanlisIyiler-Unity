using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnem : MonoBehaviour
{

    public float speed;
    public Transform target;
    public float minimumDistance;

    public float enemyHealth = 5f;


    void Start()
    {
        
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            enemyHealth -= 1f;
            if (enemyHealth <= 0f)
            {
                Destroy(gameObject);
            }

        }
    }
}
