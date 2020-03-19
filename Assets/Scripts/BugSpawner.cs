using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bug;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRateSec = 2f;
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
            nextSpawn = Time.time + Random.Range(0.5f, 2.0f);
            randX = Random.Range(-5.0f, 5.0f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            GameObject newBug = Instantiate(bug, whereToSpawn, Quaternion.identity);
            Vector3 temp = newBug.transform.localScale;
            temp.x = temp.x / Random.Range(1f, 4.0f);
            temp.y = temp.y / Random.Range(1f, 4.0f);
            newBug.transform.localScale = temp;
        }
    }
}
