using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicColliders : MonoBehaviour
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

    private void UpdateBoxCollider(BoxCollider box, Vector3 startPoint, Vector3 endPoint)
    {
        // Oblicz œrodek i wielkoœæ boxa
        Vector3 center = (startPoint + endPoint) / 2;
        Vector3 size = endPoint - startPoint;

        // Zaktualizuj transform boxa
        box.transform.position = center;
        box.transform.rotation = Quaternion.FromToRotation(Vector3.right, size);

        // Ustaw size boxa na wyliczony rozmiar
        box.size = new Vector3(size.magnitude, box.size.y, box.size.z);
    }
}