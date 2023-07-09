using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        if (scoreText)
        {
            scoreText.text = "" + GameDataManager.Instance.Score;
        }
        
    }
}
