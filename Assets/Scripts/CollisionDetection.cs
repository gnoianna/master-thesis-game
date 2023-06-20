using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Kolizja z: {other.gameObject.name}");
        Destroy(gameObject);
    }
}