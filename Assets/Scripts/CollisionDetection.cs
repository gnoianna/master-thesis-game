using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag)
        {
            GameDataManager.Instance.IncreaseScore(1);
            Destroy(gameObject);
        }
        Debug.Log($"GameObject: {other.gameObject.tag} and {gameObject.tag}");
    }
}