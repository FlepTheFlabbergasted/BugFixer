using UnityEngine;
using System;
using System.Timers;

public class Bug : MonoBehaviour
{
    public int health = 100;
    public float speed = 1;
    public float currentSpeed = 1;
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
        transform.position += transform.right * currentSpeed * Time.deltaTime;
        // If we're not already standing still
        if (currentSpeed != 0)
        {
            BeErratic();
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
