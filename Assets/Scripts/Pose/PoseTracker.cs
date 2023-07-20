using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class PoseTracker : MonoBehaviour
{
    public GameObject[] bodyPoints;
    public Transform head;
    private Transform[] bodyPointTransforms;
    private float smoothingFactor = 0.5f;

    void Start()
    {
        bodyPointTransforms = new Transform[bodyPoints.Length];
        for (int i = 0; i < bodyPoints.Length; i++)
        {
            bodyPointTransforms[i] = bodyPoints[i].transform;
        }
    }

    void Update()
    {
        string data = DataReceiver.Instance.Data;
        ParsePointsData(data);
    }

    void ParsePointsData(string data)
    {
        data = data.Trim(new char[] { '[', ']' });
        string[] points = data.Split(',');

        if (points.Length < 2)
            return;

        float leftEyeYPosition = float.Parse(points[1], CultureInfo.InvariantCulture);

        float yOffset = Mathf.Abs(head.position.y - leftEyeYPosition);
        float xOffset = head.position.x;

        for (int i = 1; i < (points.Length / 2); i++)
        {
            float x = float.Parse(points[i * 2], CultureInfo.InvariantCulture) + xOffset;
            float y = float.Parse(points[i * 2 + 1], CultureInfo.InvariantCulture) + yOffset;
            float z = head.position.z;

            Vector3 targetPosition = new Vector3(x, y, z);
            float distance = Vector3.Distance(bodyPointTransforms[i - 1].localPosition, targetPosition);


            bodyPointTransforms[i - 1].localPosition = Vector3.Lerp(bodyPointTransforms[i - 1].localPosition, targetPosition, smoothingFactor);
        }
    }
}

