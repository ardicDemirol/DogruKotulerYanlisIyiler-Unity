using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnem : MonoBehaviour
{

    public float speed;
    public Transform target;
    public float minimumDistance;

    public float enemyHealth = 5f; 
    SpriteRenderer spriteRenderer;


    /// <summary>
    ///  
    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;
    /// </summary>

    Vector3 firstPos;
    Vector3 lastPos;
    [SerializeField] Animator anim;
    Vector2 movement;


    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        firstPos = transform.position;
        
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }

        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        lastPos = transform.position;

        movement.x = lastPos.x - firstPos.x;
        movement.y = lastPos.y - firstPos.y;

        Animations();
        FlipCharcter();
    }

    private void LateUpdate()
    {
        

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

    void Animations()
    {
        anim.SetFloat("Horizontal",movement.x);
        anim.SetFloat("Vertical",movement.y);
        anim.SetFloat("Speed",1f);
    }

    private void FlipCharcter()
    {
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
