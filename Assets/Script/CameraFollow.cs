using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValue, maxValue;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        // xac dinh vi tri muc tieu co nam ngoai gioi han hay k
        //dat gioi han lon nhat va nho nhat 
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, boundPosition,
                                    smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }

}
