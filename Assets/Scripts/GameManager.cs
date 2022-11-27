using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int count = 0;
    int score = 0;
    float time = 60f;

    public bool gameOver = false;

    public Text CounterText;
    public Text ScoreText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0 && !gameOver)
        {
            time -= Time.deltaTime;
            timeText.text = "Time: " + ((int)time) + "s";
        }
        else
        {
            gameOver = true;
        }

    }

    public void UpdateCounter()
    {
        count++;
        CounterText.text = "Count: " + count;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        ScoreText.text = "Score: " + score;
    }
}
