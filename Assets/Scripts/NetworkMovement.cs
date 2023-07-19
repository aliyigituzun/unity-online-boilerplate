using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkMovement : NetworkBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    Rigidbody body;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void MovePlayer()
    {
        Debug.Log(moveDirection);
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        body.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }
}
