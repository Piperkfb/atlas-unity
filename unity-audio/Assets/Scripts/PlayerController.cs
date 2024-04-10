using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;
    public float rotatito;
    private float gravity;
    public float fallVelocity;
    private CharacterController player;
    public Transform CamTrans;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 direction = Vector3.zero;
    public Animator Anime;
    public Rigidbody playrid;

    // Start is called before the first frame update
    void Start()
    {
        Anime = GetComponentInChildren<Animator>();
        StartCoroutine(Beginning(1));
        player = GetComponent<CharacterController>();
        playrid = GetComponent<Rigidbody>();
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
            Anime.SetBool("On Ground", true);
            gravity = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpSpeed;
            }
        }
        else
        {
            Anime.SetBool("On Ground", false);
        }

        Vector3 velocity = direction * magnitude;
        velocity.y = gravity * fallVelocity;
        player.Move(velocity * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Anime.SetBool("IsRunning", true);
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotatito * Time.deltaTime);
        }
        else
        {
            Anime.SetBool("IsRunning", false);
        }
    }
    IEnumerator Beginning(float seconds)
    {
        gravity = -2f;
        yield return new WaitForSeconds(seconds);
        
    }
    private void LateUpdate() 
    {
        DidYouFall();
        AreUFalling();
        Splat();
    }
    
    void Splat()
    {
        if (Anime.GetCurrentAnimatorStateInfo(0).IsName("Getting Up"))
        {
            if (Anime.GetCurrentAnimatorStateInfo(0).normalizedTime == 1)
            {
                playrid.constraints = RigidbodyConstraints.None;
                Anime.SetBool("Respawned", false);
            }
        }
    }
    void DidYouFall()
    {
        if (transform.position.y < -20)
        {
            Anime.SetBool("Respawned", true);
            player.SimpleMove(Vector3.zero);
            
            player.transform.position = new Vector3(0, 15, 0);
            //lock player control until ani animations finish

            playrid.constraints = RigidbodyConstraints.FreezeAll;
            
        }
    }
    void AreUFalling()
    {
        if (transform.position.y < -2)
        {
            Anime.SetBool("IsFalling", true);
        }
        else
        {
            Anime.SetBool("IsFalling", false);
        }
    }
}