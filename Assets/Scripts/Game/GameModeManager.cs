using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public GameModeMenuManager gameModeMenuManager;
    public GameObject poseTracker;

    public InputActionProperty showButton;

    public AudioClip gameModeAudioClip;
    public float obstacleSpeed;
    public float gameTime;
    public int score;

    public string currentSceneName;

    private bool gameRunning = true;
    private bool gamePaused = false;

    public static GameModeManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        AudioManager.Instance.UpdateMusicAudioClip(gameModeAudioClip);
    }

    void Update()
    {
        if (showButton.action.WasPressedThisFrame() && gameRunning)
        {
            if (!gamePaused)
                PauseGame();
            else
                ResumeGame();
        }
        if (!gameRunning)
        {
            EndGame();
        }
        if (DataReceiver.Instance.DataIsEmpty())
        {
            poseTracker.SetActive(false);
            gameModeMenuManager.ShowWarningPanel();
        }
        else
        {
            poseTracker.SetActive(true);
            gameModeMenuManager.HideWarningPanel();
        }

        if (gameRunning && !gamePaused)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                EndGame();
            }
        }
    }

    public void StartGame(string sceneName)
    {
        gameRunning = true;
        gamePaused = false;
        currentSceneName = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        gameModeMenuManager.ToggleMainMenuStatus();
        gamePaused = true;
    }

    public void ResumeGame()
    {
        gameModeMenuManager.ToggleMainMenuStatus();
        gamePaused = false;
    }

    private void EndGame()
    {
        gameRunning = false;
        gameModeMenuManager.ShowGameEndPanel();
    }

    public void IncreaseScore()
    {
        score += 1;
    }

    public void QuitGameMode()
    {
        EndGame();
        AudioManager.Instance.UpdateMusicAudioClip(null);
        SceneManager.LoadScene("StartScene");
    }

    public void OnQuitGameModeButtonClick()
    {
        QuitGameMode();
    }

    public void OnResumeButtonClick()
    {
        ResumeGame();
    }

    public void OnReplayButtonClick()
    {
        StartGame(currentSceneName);
    }
}
