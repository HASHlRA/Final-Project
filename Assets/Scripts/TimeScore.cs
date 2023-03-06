using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private float score;

    public TextMeshProUGUI highScore;

    void Start()
    {
        // displays the highscore
        highScore.text = $"Best Time: {PlayerPrefs.GetInt("HighScore", 0).ToString()}";
    }


    // Update is called once per frame
    void Update()
    {
        // Adds +1 score every second passes and if the score beats the last score it will be updated in the highscore
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            ScoreText.text = $"Time: {((int)score).ToString()}";

            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)score);
                highScore.text = $"Best Time: {((int)score).ToString()}";
            }
        }
    }
}
