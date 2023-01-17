using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject target;

    void Update()
    {
        Destroy(bulletPrefab, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }

        if(target != null)
        {
            if (collision.gameObject.tag == target.tag)
            {
                Destroy(gameObject);
            }
        }
        
    }

    


}
