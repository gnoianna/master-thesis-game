using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class ModeGameManager : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject gameEndPanel;
    public GameObject statsPanel;
    public GameObject warningPanel;
    public GameObject spawner;

    public InputActionProperty showButton;

    void Update()
    {
        if (showButton.action.WasPressedThisFrame() && MainGameManager.Instance.GameRunning)
        {
            if (!MainGameManager.Instance.GamePaused)
                PauseGame();
            else
                ResumeGame();
        }
        if (!MainGameManager.Instance.GameRunning)
        {
            EndGame();
        }
        // TO-DO Add Data Receiver empty list handler
    }

    void Start()
    {
        spawner.SetActive(true);
        statsPanel.SetActive(true);
        gameMenu.SetActive(false);
        gameEndPanel.SetActive(false);
    }

    private void EndGame()
    {
        spawner.SetActive(false);
        if (!gameMenu.activeSelf)
        {
            statsPanel.SetActive(false);
            gameEndPanel.SetActive(true);
        }    
    }

    private void PauseGame()
    {
        ToggleGameMenuStatus();
        MainGameManager.Instance.PauseGame();
    }

    private void ResumeGame()
    {
        ToggleGameMenuStatus();
        MainGameManager.Instance.ResumeGame();
    }

    public void OnQuitModeButtonClick()
    {
        MainGameManager.Instance.QuitMode();
    }

    public void OnReplayButtonClick()
    {
        MainGameManager.Instance.LoadEasyMode();
    }

    public void OnResumeButtonClick()
    {
        ResumeGame();
    }

    private void ToggleGameMenuStatus()
    {
        gameMenu.SetActive(!gameMenu.activeSelf);
        spawner.SetActive(!spawner.activeSelf);
    }
}
