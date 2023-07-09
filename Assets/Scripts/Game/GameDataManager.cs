using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    public float ObstacleSpeed { get; private set; }
    public int Score { get; private set; }

    public AudioClip startAudioClip;
    public AudioClip easyAudioClip;
    public AudioClip mediumAudioClip;
    public AudioClip hardAudioClip;

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
        MusicManager.Instance.UpdateMusic(startAudioClip);
    }

    public void SetObstacleSpeed(float newSpeed)
    {
        ObstacleSpeed = newSpeed;
    }

    public void IncreaseScore(int increaseAmount)
    {
        Score += increaseAmount;
    }

    public void QuitMode()
    {
        Score = 0;
        MusicManager.Instance.UpdateMusic(startAudioClip);
        SceneManager.LoadScene("StartScene");
    }

    public void LoadEasyMode()
    {
        SetObstacleSpeed(2.0f);
        MusicManager.Instance.UpdateMusic(easyAudioClip);
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMediumMode()
    {
        SetObstacleSpeed(5.0f);
        MusicManager.Instance.UpdateMusic(mediumAudioClip);
        SceneManager.LoadScene("MainScene");
    }

    public void LoadHardMode()
    {
        SetObstacleSpeed(7.0f);
        MusicManager.Instance.UpdateMusic(hardAudioClip);
        SceneManager.LoadScene("MainScene");
    }
}
