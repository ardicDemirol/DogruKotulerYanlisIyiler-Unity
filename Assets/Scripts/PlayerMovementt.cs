using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovementt : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public Animator animator;
    BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    float playerHealth = 10f;
    bool isAlive = true;


    
    public float moveSpeed = 5f;

    Vector2 movement;
    



  

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isAlive)
        {
           // StartCoroutine(Die());

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");



            rb.velocity = new Vector2(movement.x, movement.y);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            FlipCharcter();
        }

       

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

    private void FixedUpdate()
    {
        if (isAlive)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
            
                 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            playerHealth -= 1f;
            if(playerHealth <= 0f)
            {
                
                Destroy(gameObject);
                SceneManager.LoadScene("DeathScreen");
                Invoke("Die", 2f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
        }
    }

    IEnumerator Die()
    {
        
        yield return new WaitForSeconds(2f);
        

    }
}
