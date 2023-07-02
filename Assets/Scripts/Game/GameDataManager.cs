using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public float ObstacleSpeed { get; private set; }
    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        ObstacleSpeed = 2.0f;
    }

    public void SetObstacleSpeed(float newSpeed)
    {
        ObstacleSpeed = newSpeed;
    }

    public void IncreaseScore(int increaseAmount)
    {
        Score += increaseAmount;
    }

    public void QuitGame()
    {
        Score = 0;
        SceneManager.LoadScene("StartScene");
    }


}
