using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject spawner;

    public InputActionProperty showButton;

    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            ToggleStatus();
        }
    }

    public void OnQuitButtonClick()
    {
        MainGameManager.Instance.QuitMode();
    }

    public void OnResumeButtonClick()
    {
        ToggleStatus();
    }

    private void ToggleStatus()
    {
        menu.SetActive(!menu.activeSelf);
        spawner.SetActive(!spawner.activeSelf);
    }
}
