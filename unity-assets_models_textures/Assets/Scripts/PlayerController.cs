using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;
    public float gravity = 9.8f;
    public float fallVelocity;
    private CharacterController player;
    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direction *= walkSpeed;
            if(Input.GetButton("Jump"))
            {
                direction.y = jumpSpeed;
            }
        }
        else
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), direction.y, Input.GetAxis("Vertical"));
            direction.x *= walkSpeed;
            direction.z *= walkSpeed;
        }
        direction.y -= gravity * Time.deltaTime;
        player.Move(direction * Time.deltaTime);
        

    }
}