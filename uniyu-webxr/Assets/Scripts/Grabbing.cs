using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grabbing : MonoBehaviour
{
    public MovementCamNPlayer MoveScript;
    public Vector3 StartLine;
    public Camera mainCamera;
    public Camera BCam;
    private bool isPickedUp = false;
    private Vector3 offset;
    private float zDistanceToCamera;

    void Start()
    {
        // Cursor.lockState = CursorLockMode.None;
        
        // Cache the main camera reference
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // If the object is already picked up, throw it
            if (isPickedUp)
            {
                //power gauge
                //release mouse, throw ball
                MoveScript.BBall.transform.position = StartLine;
                MoveScript.Bowling = true;                
                MoveScript.maincam.enabled = false;
                MoveScript.BCam.enabled = true;
                isPickedUp = false;
                //switch cameras

            }
            else
            {
                // Raycast to see if we clicked on the object
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 200f))
                {
                    // Check if we hit this object
                    if (hit.transform == transform)
                    {
                        MoveScript.BBall = hit.transform;
                        // Calculate the distance from the camera to the object
                        zDistanceToCamera = Vector3.Distance(transform.position, mainCamera.transform.position);
                        
                        // Calculate offset from the object's center to the point clicked
                        offset = transform.position - hit.point;
                        
                        // Pick up the object
                        isPickedUp = true;
                    }
                }
            }
        }

        // If the object is picked up, move it with the mouse
        if (isPickedUp)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = zDistanceToCamera - 1.5f;

            // Convert mouse position to world point
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(mousePosition) + offset;

            // Move the object to the new position
            transform.position = newPosition;
        }
    }
    void OnCollisionEnter(Collision clid)
    {
        if (clid.gameObject.CompareTag("pins"))
        {
            StartCoroutine(PinsFall());
        }
    }
    IEnumerator PinsFall()
    {
        
        yield return new WaitForSeconds(3);
        MoveScript.maincam.enabled = true;
        MoveScript.BCam.enabled = false;
        MoveScript.Bowling = false;
    }
}
