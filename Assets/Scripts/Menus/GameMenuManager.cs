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
    public Transform head;
    public float spawnDistance = 2;

    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            ToggleStatus();
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        if (menu)
        {
            menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
            menu.transform.forward *= -1;
        }

    }

    public void OnQuitButtonClick()
    {
        GameDataManager.Instance.QuitGame();
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