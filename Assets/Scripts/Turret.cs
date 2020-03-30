using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float fireRate = 0.3f;
    float timeToFire = 0.0f;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 100;
    float angle = 0;
    public int rotationalSpeed = 200; // degrees per second
    public GameObject bulletPrefab;
    Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

        Bullet bulletComponent = bullet.gameObject.GetComponent<Bullet>();
        bulletComponent.damage = this.damage;

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
        // Calculate the angle from the turret to the mouse
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        this.angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        // Rotate the turret at a certain speed towards the mouse, code from:
        // https://answers.unity.com/questions/826613/how-would-i-slow-down-spinning-toward-the-mouse.html
        Quaternion rotateTo = Quaternion.Euler(new Vector3(0, 0, this.angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotationalSpeed * Time.deltaTime);
        // transform.rotation = Quaternion.AngleAxis(this.angle, Vector3.forward); // Turn instantly to mouse pos
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
    }
}
