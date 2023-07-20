using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class GameModeMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameEndPanel;
    public GameObject statsPanel;
    public GameObject warningPanel;
    public GameObject spawner;

    void Start()
    {
        mainMenu.SetActive(false);
        gameEndPanel.SetActive(false);
        statsPanel.SetActive(true);
        warningPanel.SetActive(false);
        spawner.SetActive(true);
    }

    public void ShowWarningPanel()
    {
        warningPanel.SetActive(true);
    }

    public void HideWarningPanel()
    {
        warningPanel.SetActive(false);
    }

    public void ShowGameEndPanel()
    {
        spawner.SetActive(false);
        if (!mainMenu.activeSelf)
        {
            statsPanel.SetActive(false);
            gameEndPanel.SetActive(true);
        }
    }

    public void ToggleMainMenuStatus()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        spawner.SetActive(!spawner.activeSelf);
    }
}
