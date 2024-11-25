using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointVisibilityToggler : MonoBehaviour
{
    public CarMovement car; // Reference to the CarMovement script
    public Transform checkpoint; // The target checkpoint that triggers the change
    public GameObject[] objectsToHide; // Array of objects to hide
    public GameObject[] objectsToShow; // Array of objects to show
    public float triggerDistance = 1.0f; // Distance to detect when the car is at the checkpoint
    public float delay = 2.0f; // Delay before changing visibility
    private bool hasTriggered = false; // Ensure the toggle happens only once

    private void Update()
    {
        // Check if the car is close enough to the checkpoint
        if (!hasTriggered && Vector3.Distance(car.transform.position, checkpoint.position) <= triggerDistance)
        {
            hasTriggered = true; // Prevent re-triggering
            StartCoroutine(ToggleVisibilityWithDelay()); // Start the coroutine
        }
    }

    // Coroutine to handle delayed visibility toggle
    private IEnumerator ToggleVisibilityWithDelay()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        // Toggle visibility
        SetObjectsVisibility(objectsToHide, false); // Hide objects
        SetObjectsVisibility(objectsToShow, true);  // Show objects

        Debug.Log("Visibility toggled after delay.");
    }

    // Method to toggle visibility of objects
    private void SetObjectsVisibility(GameObject[] objects, bool visibility)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(visibility); // Set the active state of each object
            }
        }
    }
}
