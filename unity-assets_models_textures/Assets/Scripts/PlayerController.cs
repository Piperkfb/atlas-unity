using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2000f;
    public float jumpSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      void playermove()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, walkSpeed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -walkSpeed * Time.deltaTime);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-walkSpeed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(walkSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("space"))
        /// make a clause that if not on ground, dont jump
        {
            rb.AddForce(0, jumpSpeed * Time.deltaTime, 0)
        }
    }
}
