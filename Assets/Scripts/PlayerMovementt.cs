using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovementt : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField] float playerHealth = 10f;


    public float moveSpeed = 5f;

    Vector2 movement;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip combatSFX;
    [SerializeField] AudioClip damageSFX;


    public Joystick joystick;
    [SerializeField] private Image healthBar;
    [SerializeField] GameObject gun;
    public GameObject deathMenuUI;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        if (joystick.Horizontal >= 0.2f)
        {
            movement.x = moveSpeed;
            gun.transform.localPosition = new Vector3(0.5f, -0.4f, 0);
            gun.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (joystick.Horizontal <= -0.25f)
        {
            movement.x = -moveSpeed;
            gun.transform.localPosition = new Vector3(-0.5f, -0.4f, 0);
            gun.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (joystick.Vertical >= 0.2f)
        {
            movement.y = moveSpeed;
            gun.transform.localPosition = new Vector3(0.5f, -0.3f, 0);
            gun.transform.rotation = Quaternion.Euler(0, 0, 90);

        }
        else if (joystick.Vertical <= -0.2f)
        {
            movement.y = -moveSpeed;
            gun.transform.localPosition = new Vector3(0.5f, -0.3f, 0);
            gun.transform.rotation = Quaternion.Euler(0, 0, -90);
        }


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
            audioSource.PlayOneShot(damageSFX);
            DoSmthng(0.033f);
            if (playerHealth <= 0f)
            {
                audioSource.PlayOneShot(deathSound);
                Invoke(nameof(Destroy), 2f);
                deathMenuUI.SetActive(true);
            }
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void DoSmthng(float a)
    {
        healthBar.fillAmount -= a;
    }
}
