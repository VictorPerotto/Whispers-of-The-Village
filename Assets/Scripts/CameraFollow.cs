using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;
    [SerializeField] private float smoothing;
    
    private void FixedUpdate()
    {
        if(transform.position != targetPosition.position)
        {
            Vector3 targetPos = new Vector3 (targetPosition.position.x, targetPosition.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
    }
}
