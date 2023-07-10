using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance;

    public float ObstacleSpeed { get; private set; }
    public int Score { get; private set; }
    public float GameTime { get; private set; }
    public bool GameRunning { get; private set; }
    public bool GamePaused { get; private set; }

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
        SetObstacleSpeed(2.0f);
    }

    private void Update()
    {
        if (GameRunning && !GamePaused)
        {
            GameTime -= Time.deltaTime;
            if (GameTime <= 0)
            {
                EndGame();
            }
        }
    }

    private void StartGame()
    {
        Score = 0;
        GameTime = 20f;
        GameRunning = true;
        GamePaused = false;
    }

    public void PauseGame()
    {
        GamePaused = true;
    }

    public void ResumeGame()
    {
        GamePaused = false;
    }

    private void EndGame()
    {
        GameRunning = false;
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
        EndGame();
        MusicManager.Instance.UpdateMusic(startAudioClip);
        SceneManager.LoadScene("StartScene");
    }

    public void LoadEasyMode()
    {
        MusicManager.Instance.UpdateMusic(easyAudioClip);
        SceneManager.LoadScene("MainScene");
        StartGame();
    }

    public void LoadMediumMode()
    {
        MusicManager.Instance.UpdateMusic(mediumAudioClip);
        SceneManager.LoadScene("MainScene");
        StartGame();
    }

    public void LoadHardMode()
    {
        MusicManager.Instance.UpdateMusic(hardAudioClip);
        SceneManager.LoadScene("MainScene");
        StartGame();
    }
}
