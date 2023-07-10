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
        if (scoreValue)
        {
            scoreValue.text = MainGameManager.Instance.Score.ToString();
        }
        if (timeValue)
        {
            float gameTime = MainGameManager.Instance.GameTime;
            float minutes = Mathf.FloorToInt(gameTime / 60);
            float seconds = Mathf.FloorToInt(gameTime % 60);

            timeValue.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (bestScoreValue)
        {
            bestScoreValue.text = "Your score: " + MainGameManager.Instance.Score.ToString();
        }


    }
}
