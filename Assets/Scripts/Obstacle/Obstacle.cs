using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * GameDataManager.Instance.ObstacleSpeed;

        if (transform.position.z < -5.0f) 
        {
            Destroy(gameObject);
        }
    }
}
