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
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }







}
