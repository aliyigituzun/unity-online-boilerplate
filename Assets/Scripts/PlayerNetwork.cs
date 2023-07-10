using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class NetworkPlayer : NetworkBehaviour
{
    void Update() {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.W)) moveDir.z += +10f;
        if (Input.GetKeyDown(KeyCode.S)) moveDir.z += -10f;
        if (Input.GetKeyDown(KeyCode.A)) moveDir.x += -10f;
        if (Input.GetKeyDown(KeyCode.D)) moveDir.x += +10f;

        float moveSpeed = 30f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
