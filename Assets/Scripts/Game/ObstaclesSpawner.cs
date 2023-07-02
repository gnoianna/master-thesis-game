using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject leftObstacle;
    public GameObject rightObstacle;
    public Transform[] leftPositions;
    public Transform[] rightPositions;

    public float step = 0.3f;
    public float timer;

    private int spawnSide;

    void Update()
    {
        if(timer > step)
        {
            GameObject newObstacle;
            spawnSide = Random.Range(0, 2);

            if (spawnSide != 0)
            {
                newObstacle = Instantiate(leftObstacle, leftPositions[Random.Range(0, leftPositions.Length)]);
            } else {
                newObstacle = Instantiate(rightObstacle, rightPositions[Random.Range(0, rightPositions.Length)]);
            }

            newObstacle.transform.localPosition = Vector3.zero;
            timer -= step;
        }
        timer += Time.deltaTime;
    }
}
