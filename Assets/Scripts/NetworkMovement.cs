using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkMovement : NetworkBehaviour
{
    private Rigidbody body;
    public float speed;
    public float rotationSpeed;
    public float acceleration;
    public float maxSpeed;
    private float vertical;
    private float horizontal;
    private Vector3 movement;

    private int counter; //temporary


    void Start()
    {
        body = GetComponent<Rigidbody>();
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        movement = new Vector3(horizontal, 0f, vertical);
        body.AddForce(movement * acceleration, ForceMode.Acceleration);
        body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
        transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);

        counter++; //temporary
        while(counter > 100)
        {
            Debug.Log(body.velocity);
            counter = 0;
        }
        

    }
}
