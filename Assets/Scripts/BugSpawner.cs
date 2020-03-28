using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bug;
    float randX;
    public float spawnRateSec = 1f;
    float nextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            // Spawntime
            nextSpawn = Time.time + Random.Range(0.5f, 2.0f);

            SpawnBug();
        }
    }

    public GameObject SpawnBug()
    {
        // Looks
        Vector3 scale = bug.transform.localScale;
        scale.x /= Random.Range(0.8f, 3f);
        scale.y /= Random.Range(2f, 3.5f);
        Color color = randomColor();

        float speed = Random.Range(2f, 15f);

        // Spawn position, outside the viewport on right or left side
        Vector2 viewPortSide;
        Vector2 spawnPos;
        int direction;
        if (Random.value < 0.5f)
        {
            viewPortSide = new Vector2(0f, 0f);
            spawnPos = Camera.main.ViewportToWorldPoint(viewPortSide);
            spawnPos.x -= scale.x * 2.5f;
            spawnPos.y += scale.y * 1.5f;
            direction = 1;
        }
        else
        {
            viewPortSide = new Vector2(1f, 0f);
            spawnPos = Camera.main.ViewportToWorldPoint(viewPortSide);
            spawnPos.x += scale.x * 2.5f;
            spawnPos.y += scale.y * 1.5f;
            direction = -1;
        }

        GameObject newBug = Instantiate(bug, spawnPos, Quaternion.identity);
        Bug bugComponent = newBug.gameObject.GetComponent<Bug>();

        bugComponent.speed = speed;
        bugComponent.currentSpeed = speed;
        bugComponent.xForwardDirection = direction;

        newBug.transform.localScale = scale;
        newBug.GetComponent<Renderer>().material.color = color;

        return newBug;
    }

    Color randomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }
}
