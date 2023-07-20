using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.tag == gameObject.tag)
        {
            GameModeManager.Instance.IncreaseScore();
            AudioManager.Instance.PlayCollisionSound();
            Destroy(gameObject);
        }
    }
}