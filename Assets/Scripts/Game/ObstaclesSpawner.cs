using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public Transform[] positions1;
    public Transform[] positions2;

    public float step = 0.3f;
    public float timer;

    private int spawnSide;

    void Update()
    {
        if(timer > step)
        {
            GameObject newObstacle;
            Transform position;
            spawnSide = Random.Range(0, 2);

            if (spawnSide != 0)
            {
                position = positions1[Random.Range(0, positions1.Length)];
                newObstacle = Instantiate(obstacle1, position);
            } else {
                position = positions2[Random.Range(0, positions2.Length)];
                newObstacle = Instantiate(obstacle2, position);
            }

            newObstacle.transform.localPosition = Vector3.zero;
            timer -= step;
        }
        timer += Time.deltaTime;
    }
}
