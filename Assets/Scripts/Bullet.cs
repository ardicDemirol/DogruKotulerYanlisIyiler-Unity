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
        Destroy(bulletPrefab, 2f);
    }


}
