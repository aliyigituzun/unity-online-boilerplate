using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{


    [SerializeField] private Button ServerButton;
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;

    private void Awake()
    {
        ServerButton.onClick.AddListener(() => {
            Debug.Log("Server");
            NetworkManager.Singleton.StartServer();
            
        });
        HostButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
            Debug.Log("Host");
        });
        ClientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            Debug.Log("Host");

        });
    }


}