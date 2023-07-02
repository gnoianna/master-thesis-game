using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class PoseTracker : MonoBehaviour
{
    public GameObject[] bodyPoints;
    public Transform head;

    void Update()
    {
        string data = DataReceiver.instance.data;
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(",");
        float step = 10.0f * Time.deltaTime;

        if (points.Length > 1)
        {
            float leftEyeYPosition = float.Parse(points[1], CultureInfo.InvariantCulture);
            float yOffset = Mathf.Abs(head.transform.position.y - leftEyeYPosition);
            float xOffset = head.transform.position.x;

            float zPosition = head.transform.position.z;

            for (int i = 1; i < (points.Length / 3); i++)
            {
                float prevX = bodyPoints[i - 1].transform.localPosition.x;
                float prevY = bodyPoints[i - 1].transform.localPosition.y;
                float x = float.Parse(points[i * 3], CultureInfo.InvariantCulture) + xOffset;
                float y = float.Parse(points[i * 3 + 1], CultureInfo.InvariantCulture) + yOffset;
                float prevCurrXDifference = Mathf.Abs(prevX) - Mathf.Abs(x);
                float prevCurrYDifference = Mathf.Abs(prevY) - Mathf.Abs(y);

                if (prevCurrXDifference < 0.1f && prevCurrXDifference > 0.2f)
                {
                    x = prevX;
                }
                if (prevCurrYDifference < 0.1f && prevCurrYDifference > 0.2f)
                {
                    y = prevY;
                }
                bodyPoints[i - 1].transform.localPosition = Vector3.MoveTowards(bodyPoints[i - 1].transform.localPosition, new Vector3(x, y, zPosition), step);
                //bodyPoints[i - 1].transform.localPosition = Vector3.Lerp(bodyPoints[i - 1].transform.localPosition, new Vector3(x, y, zPosition - 0.1f), step);

            }
        }
    }
}
