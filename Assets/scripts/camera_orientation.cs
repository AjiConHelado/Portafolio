using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_orientation : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerobj;
    public Rigidbody rb;
    public float rotationspd;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 viewdir = player.position - new Vector3 (transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewdir.normalized;
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        Vector3 inputdir =  orientation.forward * verticalinput + orientation.right * horizontalinput;

        if (inputdir != Vector3.zero)
        {
            playerobj.forward = Vector3.Slerp (playerobj.forward, inputdir.normalized, Time.deltaTime*rotationspd);
        }
    }
}
