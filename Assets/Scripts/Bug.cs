using UnityEngine;
using System;
using System.Timers;

public class Bug : MonoBehaviour
{
    public int health = 100;
    public float speed = 1;
    public float currentSpeed = 1;
    public int xForwardDirection = 1;
    public int velY = 0;
    public float erraticLevel = 9.9f;
    private static System.Timers.Timer erraticTimer;
    public Rigidbody2D rb;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If we use "transform.position" the bugs glitch when hitting a wall
        // transform.position += transform.right * currentSpeed * Time.deltaTime;
        rb.velocity = new Vector3(xForwardDirection * currentSpeed, velY * currentSpeed, 0);

        // If we're not already standing still
        if (currentSpeed != 0)
        {
            BeErratic();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Vector3 position = collision.gameObject.transform.position;
            if (xForwardDirection > 0 && position.x > 0)
            {
                // Right wall
                Debug.Log("Hit the right wall");
                // xForwardDirection *= -1;
                velY = 1;
            }
            else if (xForwardDirection < 0 && position.x < 0)
            {
                // Left wall
                Debug.Log("Hit the left wall");
                // xForwardDirection *= -1;
                velY = 1;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        ScoreScript.scoreValue += 1;
    }


    void BeErratic()
    {
        // X% chance that we stop
        if (UnityEngine.Random.Range(0f, 10f) > erraticLevel)
        {
            StopFor(UnityEngine.Random.Range(1000, 2000));
        }
        // else if (UnityEngine.Random.Range(0f, 10f) > erraticLevel)
        // {
        //     // TODO: Change direction
        // }
    }

    void StopFor(int duration)
    {
        currentSpeed = 0;

        // Create a timer with a two second interval.
        erraticTimer = new System.Timers.Timer(duration);
        // Hook up the Elapsed event for the timer.
        erraticTimer.Elapsed += OnTimedEvent;
        erraticTimer.AutoReset = true;
        erraticTimer.Enabled = true;
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs elapsedEventArg)
    {
        currentSpeed = speed;
    }
}
