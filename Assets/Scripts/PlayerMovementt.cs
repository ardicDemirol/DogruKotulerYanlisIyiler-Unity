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
    float playerHealth = 80f;
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

    //IEnumerator Die()
    //{
    //    if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Projectile")))
    //    {
    //        playerHealth -= 10f;
    //        if(playerHealth <= 0)
    //        {

    //            isAlive = false;
    //            SceneManager.LoadScene("DeathScreen");
    //            yield return new WaitForSeconds(2f);
    //            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
    //        }
            
    //    }
    //}
}
