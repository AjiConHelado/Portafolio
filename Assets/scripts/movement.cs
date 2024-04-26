using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [Header("groundcheck")]
    public float grounDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("movement")]
    public float movespeed;
    public Transform orientation;
    float horizontalinput;
    float verticalinput;

    Vector3 movedir;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        rb.freezeRotation = true;

    }
    void FixedUpdate()
    {
        moveplayer();
    }
    // Update is called once per frame
    void Update()
    {
       
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        myinput();
        if (grounded)
        {
            rb.drag = grounDrag;
           
        }
        else
        {
            rb.drag = 0f;
            
        }
        speedcontrol();
    }
    private void myinput()
    {
            horizontalinput = Input.GetAxisRaw("Horizontal");
            verticalinput = Input.GetAxisRaw("Vertical");
       
    }
    private void moveplayer()
    {

        movedir = orientation.forward * verticalinput+orientation.right * horizontalinput ;
        rb.AddForce(movedir.normalized * movespeed * 10f, ForceMode.Force);
    }
    private void speedcontrol() 
    {
        Vector3 flatVel =new Vector3(rb.velocity.x,0f,rb.velocity.z);
        if(flatVel.magnitude>movespeed)
        {
            Vector3 limitedVel =flatVel.normalized*movespeed;
            rb.velocity = new Vector3(limitedVel.x,rb.velocity.y,limitedVel.z);
        }
       
    }
}
