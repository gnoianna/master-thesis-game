using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{

    private void OnTriggerEnter(Collider body)
    {
        if (body.gameObject.tag == gameObject.tag)
        {
            GameDataManager.Instance.IncreaseScore(1);
            MusicManager.Instance.PlayCollisionSound();
            Destroy(gameObject);
        }
    }
}