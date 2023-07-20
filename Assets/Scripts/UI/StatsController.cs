using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsController : MonoBehaviour
{
    public TMP_Text scoreValue;
    public TMP_Text bestScoreValue;
    public TMP_Text timeValue;

    void Update()
    {
        if (timeValue)
        {
            float gameTime = GameModeManager.Instance.gameTime;
            float minutes = Mathf.FloorToInt(gameTime / 60);
            float seconds = Mathf.FloorToInt(gameTime % 60);

            timeValue.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (scoreValue && bestScoreValue)
        {
            string score = GameModeManager.Instance.score.ToString();
            scoreValue.text = score;
            bestScoreValue.text = "Your score: " + score;
        }
    }
}
