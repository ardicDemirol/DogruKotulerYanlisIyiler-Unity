using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth =3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }



    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
