using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int major = scoreValue / 100;
        int minor = (scoreValue / 10) % 10;
        int patch = scoreValue % 10;
        score.text = "v" + major + "." + minor + "." + patch;
    }
}
