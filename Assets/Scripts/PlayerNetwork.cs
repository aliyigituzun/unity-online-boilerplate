using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    void Update() {
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.W)) moveDir.z += +1f;
        if (Input.GetKeyDown(KeyCode.S)) moveDir.z += -1f;
        if (Input.GetKeyDown(KeyCode.A)) moveDir.x += -1f;
        if (Input.GetKeyDown(KeyCode.D)) moveDir.x += +1f;
    }
}
