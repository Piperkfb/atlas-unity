using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCamNPlayer : MonoBehaviour
{
    public Camera BCam;
    public Camera maincam;
    public float mouseSensitivity = 200f;
    public Transform BBall;
    public float Bspeed = 1f;
    float xRotation = 0f;
    public float speed = 5f;
    public bool Bowling;
    private Vector3 Bforward = new Vector3(0f, 0f, 0.04f);

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Bowling == false)
        {   
            BeginControl();
        }
        else if (Bowling == true)
        {
            BowlingStart();
        }

    }
    void BeginControl()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust xRotation to clamp vertical look
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera around the X-axis for vertical look
        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);

        //controls

        // Get input for moving forward and backward
        float moveDirection = Input.GetAxis("Vertical"); // W/S or Up/Down arrows

        // Move the player forward and backward based on the player's local forward direction
        Vector3 move = Vector3.forward * moveDirection * speed * Time.deltaTime;

        // Apply the movement to the player's position
        transform.Translate(move, Space.World);
    }
    void BowlingStart()
    {
        // transform.position = new Vector3(-16.9f, 7.3f, -22.8f);
        // transform.Rotate = new Quaternion(0.4f, 0, 0);
        float BowlingDirection = Input.GetAxis("Horizontal");
        //Move the ball during bowling
        Vector3 move = Vector3.right * BowlingDirection * Bspeed * Time.deltaTime;
        BBall.transform.Translate(move + Bforward, Space.World);
    }
}
