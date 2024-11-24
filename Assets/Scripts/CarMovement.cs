using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform checkPoint1;
    public Transform checkPoint2;

    // Speed of car
    public float speed = 0.1f;

    //Car rotation speed after reaching checkpoint
    public float rotationSpeed = 1.0f;

    //Distance from checkpoint car will reach the checkpoint
    public float checkpointDist = 2.0f;
    private Transform currentPoint;

    // Flag to determine if the car can move
    private bool canMove = false;

    private void Update()
    {
        // Exit Update if the car is not allowed to move
        if (!canMove) return;

        if (currentPoint == null) return;

        // Move the car towards the current checkpoint
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed*Time.deltaTime);

        // Rotate the car to face the target
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, currentPoint.position - transform.position, rotationSpeed*Time.deltaTime, 1.0f);
        
        transform.rotation = Quaternion.LookRotation(newDirection);
        
        // Check if the car has reached the current checkpoint
        if (Vector3.Distance(transform.position, currentPoint.position) < checkpointDist)
        {
            canMove = false; // Stop moving and wait for the next interaction
        }
    }

    // Public method to set the target checkpoint
    public void SetTargetCheckpoint(Transform checkpoint)
    {
        currentPoint = checkpoint;
    }

    // Method to enable car movement
    public void EnableMovement()
    {
        canMove = true;
    }
}