using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;
    public float rotatito;
    public float gravity;
    public float fallVelocity;
    private CharacterController player;
    public Transform CamTrans;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ///delcaring amd building
        float Hori = Input.GetAxis("Horizontal");
        float Verti = Input.GetAxis("Vertical"); 

        camForward = CamTrans.forward;
        camRight = CamTrans.right;
        camForward.y = 0;
        camRight.y = 0;

        ///camera relatives
        Vector3 forwardRelative = Verti * camForward;
        Vector3 rightRelative = Hori * camRight;

        /// direction set
        direction = forwardRelative + rightRelative;

        float magnitude = Mathf.Clamp01(direction.magnitude) * walkSpeed;
        direction.Normalize();

        ///jump and gravity
        gravity += Physics.gravity.y * Time.deltaTime;

        if (player.isGrounded)
        {
            gravity = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpSpeed;
            }
        }

        Vector3 velocity = direction * magnitude;
        velocity.y = gravity;
        player.Move(velocity * Time.deltaTime);
        
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotatito * Time.deltaTime);
        }
    }
    private void LateUpdate() 
    {
        DidYouFall();    
    }
    void DidYouFall()
    {
        if (transform.position.y < -20)
        {
        player.SimpleMove(Vector3.zero);
        player.transform.position = new Vector3(0, 15, 0);
        }
    }
}