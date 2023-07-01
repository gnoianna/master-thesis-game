using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void OnButtonClick(float obstacleSpeed)
    {
        Debug.Log("OnButtonClick here!");
        GameDataManager.Instance.SetObstacleSpeed(obstacleSpeed);
        SceneManager.LoadScene("MainScene");
    }
}
