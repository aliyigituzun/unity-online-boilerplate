using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode.Transports.UTP;

public class NetworkManagerUI : MonoBehaviour
{


    [SerializeField] private Button ServerButton;
    [SerializeField] private Button HostButton;
    [SerializeField] private Button ClientButton;
    [SerializeField] private GameObject IpField;
    [SerializeField] private GameObject NetworkManagere;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Disconnect();
        }
        
    }


    public void Disconnect(){
        NetworkManager.Singleton.Shutdown();
        Debug.Log("Disconnect");
        IpField.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void StartClienting(){
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client");
        IpField.SetActive(false);
    }


    public void StartHosting(){
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host");
        IpField.SetActive(false);
    }


    public void StartServing(){
        NetworkManager.Singleton.StartServer();
        Debug.Log("Server");
        IpField.SetActive(false);
    }


    public void Ip_Changed(string _ipe){
        UnityTransport thisisimportant = NetworkManagere.GetComponent<UnityTransport>();
        thisisimportant.ConnectionData.Address = _ipe;
    }


}