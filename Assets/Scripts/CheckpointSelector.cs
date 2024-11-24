using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointSelector : MonoBehaviour
{
    public CarMovement car; // Reference to the car movement script
    public GameObject uiWindow; // UI confirmation window
    private Transform selectedCheckpoint; // Currently selected checkpoint

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a checkpoint
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Checkpoint"))
                {
                    selectedCheckpoint = hit.transform; // Store the selected checkpoint
                    ShowConfirmationWindow(); // Display the confirmation UI
                }
            }
        }
    }

    // Show the confirmation window
    void ShowConfirmationWindow()
    {
        uiWindow.SetActive(true);
    }

    // Called when the player confirms the car should move
    public void ConfirmMove()
    {
        car.SetTargetCheckpoint(selectedCheckpoint); // Set the target checkpoint
        car.EnableMovement(); // Start the car movement
        uiWindow.SetActive(false); // Hide the confirmation window
    }

    // Called when the player cancels the action
    public void CancelMove()
    {
        uiWindow.SetActive(false); // Hide the confirmation window
        selectedCheckpoint = null; // Clear the selected checkpoint
    }
}