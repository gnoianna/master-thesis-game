using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickHandler : MonoBehaviour
{
    public void OnButtonClick(float ballSpeed)
    {
        GameData.obstacleSpeed = ballSpeed;
        SceneManager.LoadScene("MainGame");
    }
}
