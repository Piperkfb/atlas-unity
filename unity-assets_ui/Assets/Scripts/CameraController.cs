using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    public Transform the;
    public GameObject player;
    public float MouseSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        the = GetComponent<Transform>();
       offset = the.position - player.transform.position; 
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * MouseSpeed, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * MouseSpeed, Vector3.left) * offset;
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }
        else
        {
            transform.position = player.transform.position + offset;
        }
    }
}
