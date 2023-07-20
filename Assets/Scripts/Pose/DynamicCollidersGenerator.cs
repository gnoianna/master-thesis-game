using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCollidersGenerator : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;

    public BoxCollider box1;
    public BoxCollider box2;

    private void Update()
    {
        UpdateBoxCollider(box1, point1.position, point2.position);
        UpdateBoxCollider(box2, point2.position, point3.position);
    }

    private void UpdateBoxCollider(BoxCollider box, Vector3 start, Vector3 end)
    {
        Vector3 size = end - start;
        box.transform.position = (start + end) / 2;
        box.transform.rotation = Quaternion.FromToRotation(Vector3.right, size);
        box.size = new Vector3(size.magnitude, box.size.y, box.size.z);
    }
}