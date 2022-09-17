using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    private float playerHealth = 100f;
    public GameObject player;

    void Start()
    {
        targetPosition = FindObjectOfType<PlayerMovementt>().transform.position;

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPosition,speed * Time.deltaTime);

        if(transform.position == targetPosition)
        {
            Destroy(gameObject);
            //playerHealth -= 20f;
            //if (playerHealth <= 0)
            //{
            //    PlayerDead();
            //    Destroy(player);
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //}

        }
    }

    //void PlayerDead()
    //{
    //    Debug.Log("Player dead");
    //}
}
