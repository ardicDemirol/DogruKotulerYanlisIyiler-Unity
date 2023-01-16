using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoints;
    public GameObject bulletPrefab;


    public float bulletForce = 20f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fireSound;

    public bool canShoot = true;



    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Click()
    {
        if (canShoot == true)
        {
            ShootBullet();
            audioSource.PlayOneShot(fireSound);
            CinemachineShake.Instance.ShakeCamera(5f, .1f);
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoints.position, firePoints.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoints.right * bulletForce, ForceMode2D.Impulse);
    }
}
