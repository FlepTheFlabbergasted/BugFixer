using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate = 0.3f;
    float timeToFire = 0.0f;
    public float damage = 10;
    float angle = 0;
    public int rotationalSpeed = 150; // n degrees per second
    public GameObject bulletPrefab;
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
        // Let the player shoot as fast as the player can. But still be able to hold down the button to fire at a set speed
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            timeToFire = Time.time + fireRate;
        }
        else if (Input.GetButton("Fire1") && Time.time > timeToFire)
        {
            timeToFire = Time.time + fireRate;
            Shoot();
        }

        RotateTowardsMouse();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        // Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        // RaycastHit2D hitInfo = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition);
        // Debug.DrawLine(firePointPosition, mousePosition);

        // if (hitInfo.collider != null)
        // {
        //     // Debug.DrawLine(firePointPosition, hit.point, Color.red);
        //     Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage");
        // }
    }

    void RotateTowardsMouse()
    {
        // Point the Turret towards the mouse
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        this.angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(this.angle, Vector3.forward); // Turn instantly to mouse pos

        // Rotate the turret at a certain speed towards the mouse, code from:
        // https://answers.unity.com/questions/826613/how-would-i-slow-down-spinning-toward-the-mouse.html
        Quaternion rotateTo = Quaternion.Euler(new Vector3(0, 0, this.angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotationalSpeed * Time.deltaTime);
    }
}
