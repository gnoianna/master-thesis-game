using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class PoseTracker : MonoBehaviour
{
    public GameObject[] bodyPoints;
    public Transform head;
    private Transform[] pointTransforms;
    private float smoothingFactor = 0.5f;

    void Start()
    {
        pointTransforms = new Transform[bodyPoints.Length];
        for (int i = 0; i < bodyPoints.Length; i++)
        {
            pointTransforms[i] = bodyPoints[i].transform;
        }
    }

    void Update()
    {
        string data = DataReceiver.Instance.Data;
        ParsePointsData(data);
    }

    float ParseToFloat(string point)
    {
        return float.Parse(point, CultureInfo.InvariantCulture);
    }

    void ParsePointsData(string data)
    {
        data = data.Trim(new char[] { '[', ']' });
        string[] points = data.Split(',');

        if (points.Length < 2)
            return;

        float leftEyeYPosition = ParseToFloat(points[1]);
        float xOffset = head.position.x;
        float yOffset = Mathf.Abs(head.position.y - leftEyeYPosition);

        for (int i = 1; i < (points.Length / 2); i++)
        {
            float x = ParseToFloat(points[i * 2]) + xOffset; //Tu te¿ mo¿e nie dzia³aæ
            float y = ParseToFloat(points[i * 2 + 1]) + yOffset;
            float z = head.position.z;

            Vector3 currentPosition = pointTransforms[i - 1].localPosition; //Tu mo¿e siê zjebaæ
            Vector3 targetPosition = new Vector3(x, y, z);

            pointTransforms[i - 1].localPosition = Vector3.Lerp(currentPosition, targetPosition, smoothingFactor);
        }
    }
}

