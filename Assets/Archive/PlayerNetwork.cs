using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;


public class NetworkPlayer : NetworkBehaviour {

    [SerializeField] private Transform spawnedObjectPrefab;

    public struct MyCustomData : INetworkSerializable
    {
        public int _int;
        public bool _bool;
        public FixedString128Bytes message;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _int);
            serializer.SerializeValue(ref _bool);
        }
    }
    

    void Update() {

        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            TestServerRpc();
        }
        
        
    }

    [ServerRpc]
    private void TestServerRpc()
    {
        Transform spawnedObjectTransform = Instantiate(spawnedObjectPrefab);
        spawnedObjectTransform.GetComponent<NetworkObject>().Spawn(true);
        
    }
    [ClientRpc]
    private void TestClientRpc(ClientRpcParams clientRpcParams)
    {
        Debug.Log("Cliento" + " ; " + OwnerClientId);
    }





}
