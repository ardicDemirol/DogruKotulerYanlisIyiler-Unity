using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;
    public GameObject player;

    void Start()
    {
        targetPosition = FindObjectOfType<PlayerMovementt>().transform.position;

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPosition,speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            Destroy(gameObject);
        }
    }
}
