using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class AimWeapon : PlayerAimWeapon
{
    public event EventHandler<OnShootEventArgs> OnShoot;

    public class OnShootEventArgs: EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
    }


    [SerializeField] Transform aimTransform;
    private Animator aimAnimator;
    [SerializeField] Transform aimGunEndPointTransform;

    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Transform firePoint;
    
    void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        //aimGunEndPointTransform = aimTransform.GetComponent<Transform>();
    }

    void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShakeController.Instance.ShakeCamera(3f,.1f);

            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(mousePosition * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 3f);
            

            

           // aimAnimator.SetTrigger("Shoot");
            //OnShoot?.Invoke(this, new OnShootEventArgs
            //{
            //    gunEndPointPosition = aimGunEndPointTransform.position,
            //    shootPosition = mousePosition
            //});
        }
    }
}
