using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform checkPoint1;
    public Transform checkPoint2;
    public float speed = 0.1f;
    public float rotationSpeed = 1.0f;
    public float checkpointDist = 2.0f;
    private Transform currentPoint;

    private void Update()
    {
        if (currentPoint == null)
        {
            currentPoint = checkPoint1;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed*Time.deltaTime);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, currentPoint.position - transform.position, rotationSpeed*Time.deltaTime, 1.0f);
        
        transform.rotation = Quaternion.LookRotation(newDirection);
        
        if (Vector3.Distance(transform.position, currentPoint.position) < checkpointDist)
        {
            if (currentPoint == checkPoint1)
            {
                currentPoint = checkPoint2;
            }
            else currentPoint = checkPoint1;
        }
    }
}