using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    

    void Start()
    {
        
    }

    void Update()
    {
        Destroy(bulletPrefab, 3f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(effect);

        if(collision.tag == "Interactable")
        {
            Destroy(bulletPrefab);
        }
    }







}
