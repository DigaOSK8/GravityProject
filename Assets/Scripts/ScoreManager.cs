using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();

        score = 0;
    }

    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        if(score < 0)
        {
            score = 0;
        }
    }

    public static void Reset()
    {
        score = 0;
    }
}
