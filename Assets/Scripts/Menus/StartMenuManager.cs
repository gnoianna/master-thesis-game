using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public CanvasGroup mainPanel;
    public CanvasGroup gameModesPanel;
    public CanvasGroup seetingsPanel;

    private void Start()
    {
        ShowMainPanel();
    }

    public void ShowMainPanel()
    {
        TogglePanel(mainPanel, true);
        TogglePanel(gameModesPanel, false);
        TogglePanel(seetingsPanel, false);
    }

    public void ShowGameModesPanel()
    {
        TogglePanel(mainPanel, false);
        TogglePanel(gameModesPanel, true);
        TogglePanel(seetingsPanel, false);
    }

    public void ShowSettingsPanel()
    {
        TogglePanel(mainPanel, false);
        TogglePanel(gameModesPanel, false);
        TogglePanel(seetingsPanel, true);
    }

    private void TogglePanel(CanvasGroup panel, bool isVisible)
    {
        panel.alpha = isVisible ? 1.0f : 0.0f;
        panel.blocksRaycasts = isVisible;
        panel.interactable = isVisible;
    }

    public void EasyMode()
    {
        GameDataManager.Instance.LoadEasyMode();
    }

    public void MediumMode()
    {
        GameDataManager.Instance.LoadMediumMode();
    }

    public void HardMode()
    {
        GameDataManager.Instance.LoadHardMode();
    }
}
