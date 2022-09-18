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
    [SerializeField] float playerHealth =10f;
    bool isAlive = true;


    
    public float moveSpeed = 5f;

    Vector2 movement;




    public AudioClip typeSound;
    AudioSource audSrc;
    public AudioClip combatSFX;
    AudioSource comSrc;






    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        comSrc = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        comSrc.PlayOneShot(combatSFX);

    }

    void Update()
    {

        
        

        movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");



            rb.velocity = new Vector2(movement.x, movement.y);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            FlipCharcter();
        

       

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
            
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
            
                 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            playerHealth -= 1f;
            if(playerHealth <= 0f)
            {
                audSrc.PlayOneShot(typeSound);
                Destroy(gameObject);
                RestartLevel();
                
            }
            
        }
    }


    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Invoke("ReScene",2f);

    }

   
}
