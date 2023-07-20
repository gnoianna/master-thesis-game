using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public Transform from;
    public Transform to;

    void Update()
    {
        lineRenderer.SetPosition(0, from.position);
        lineRenderer.SetPosition(1, to.position);
    }
}
