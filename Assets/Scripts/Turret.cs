﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate = 0;
    public float damage = 10;
    public float angle = 0;
    public LayerMask whatToHit;
    public GameObject bulletPrefab;

    float timeToFire = 0;
    Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No FirePoint found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

        // Point the Turret towards the mouse
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        this.angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(this.angle, Vector3.forward);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hitInfo = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition);
        // Debug.DrawLine(firePointPosition, mousePosition);

        // if (hitInfo.collider != null)
        // {
        //     // Debug.DrawLine(firePointPosition, hit.point, Color.red);
        //     Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage");
        // }
    }
}