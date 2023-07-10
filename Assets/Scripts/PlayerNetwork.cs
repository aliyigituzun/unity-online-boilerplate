using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


public class NetworkPlayer : NetworkBehaviour
{

    private NetworkVariable<int> randomNumber = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    
        void Update() {
        Debug.Log(OwnerClientId + "" + randomNumber.Value);

        if (Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = Random.Range(0, 100);
        }
            if (!IsOwner) return;
        Vector3 moveDir = new Vector3(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.W)) moveDir.z += +10f;
        if (Input.GetKeyDown(KeyCode.S)) moveDir.z += -10f;
        if (Input.GetKeyDown(KeyCode.A)) moveDir.x += -10f;
        if (Input.GetKeyDown(KeyCode.D)) moveDir.x += +10f;

        float moveSpeed = 30f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
