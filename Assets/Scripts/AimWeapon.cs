using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class AimWeapon : PlayerAimWeapon
{

    public Transform aimTransform;
    private Animator aimAnimator;
    
    void Awake()
    {
        //aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
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
            aimAnimator.SetTrigger("Shoot");
        }
    }
}
