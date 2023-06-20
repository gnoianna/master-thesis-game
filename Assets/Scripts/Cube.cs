using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float cubeSpeed = 1.0f;

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * cubeSpeed;

        // Destroy element after reaching specific position
        if (transform.position.z < -5.0f) 
        {
            Destroy(gameObject);
        }
    }
}
