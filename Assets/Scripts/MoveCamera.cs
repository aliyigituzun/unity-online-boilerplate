using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MoveCamera : NetworkBehaviour
{
    public float sensX;
    public float sensY;

    public Transform cameraPosition;
    [SerializeField] private Camera urcamera;

    float xRotation;
    float yRotation;

    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (!IsOwner) { 
        return; 
        }
        urcamera.enabled = true;
        transform.position = cameraPosition.position;
    }


    void Update()
    {
        if (IsOwner){
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        cameraPosition.rotation = Quaternion.Euler(0, yRotation, 0f);
        }
    }
}
