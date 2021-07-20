using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody rb;

    private float moveX;
    private float moveZ;

    public float moveSpeed;

    private bool jump;
    public int jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        rb.AddForce(moveX * moveSpeed, 0, moveZ * moveSpeed);



        jump = Input.GetButtonDown("Jump");

        if (jump) {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        
    }
}
