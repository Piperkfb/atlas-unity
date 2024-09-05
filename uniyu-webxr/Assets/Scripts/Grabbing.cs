using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{

    private Camera mainCamera;
    private bool isPickedUp = false;
    private Vector3 offset;
    private float zDistanceToCamera;

    void Start()
    {
        // Cursor.lockState = CursorLockMode.None;
        
        // Cache the main camera reference
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // If the object is already picked up, drop it
            if (isPickedUp)
            {
                isPickedUp = false;
                return;
            }

            // Raycast to see if we clicked on the object
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if we hit this object
                if (hit.transform == transform)
                {
                    // Calculate the distance from the camera to the object
                    zDistanceToCamera = Vector3.Distance(transform.position, mainCamera.transform.position);
                    
                    // Calculate offset from the object's center to the point clicked
                    offset = transform.position - hit.point;
                    
                    // Pick up the object
                    isPickedUp = true;
                }
            }
        }

        // If the object is picked up, move it with the mouse
        if (isPickedUp)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = zDistanceToCamera;

            // Convert mouse position to world point
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(mousePosition) + offset;

            // Move the object to the new position
            transform.position = newPosition;
        }
    }
}
