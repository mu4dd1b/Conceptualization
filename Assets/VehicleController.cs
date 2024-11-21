using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class VehicleController : MonoBehaviour
{
    // Reference to the car's NavMeshAgent component
    private NavMeshAgent navAgent;

    // The layer that represents the clickable terrain
    public LayerMask Road;

    void Start()
    {
        // Initialize the NavMeshAgent
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hit a tile on the terrain
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Road))
            {
                // Set the destination of the NavMeshAgent to the hit point
                navAgent.SetDestination(hit.point);
            }
        }
    }
}
