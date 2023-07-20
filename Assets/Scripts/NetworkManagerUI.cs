using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode.Transports.UTP;

public class NetworkManagerUI : MonoBehaviour
{


    [SerializeField] private GameObject ServerButton;
    [SerializeField] private GameObject HostButton;
    [SerializeField] private GameObject ClientButton;
    [SerializeField] private GameObject IpField;
    [SerializeField] private GameObject NetworkManagere;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Disconnect();
        }
        
    }

    public void HideButtons(){
        IpField.SetActive(false);
        ClientButton.SetActive(false);
        HostButton.SetActive(false);  
        ServerButton.SetActive(false);
    }

    public void ShowButtons(){
        IpField.SetActive(true);
        ClientButton.SetActive(true);
        HostButton.SetActive(true);  
        ServerButton.SetActive(true);
    }

    public void Disconnect(){
        NetworkManager.Singleton.Shutdown();
        Debug.Log("Disconnect");
        ShowButtons();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void StartClienting(){
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client");
        HideButtons();
    }


    public void StartHosting(){
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host");
        HideButtons();
    }


    public void StartServing(){
        NetworkManager.Singleton.StartServer();
        Debug.Log("Server");
        HideButtons();
    }


    public void Ip_Changed(string _ipe){
        UnityTransport thisisimportant = NetworkManagere.GetComponent<UnityTransport>();
        thisisimportant.ConnectionData.Address = _ipe;
    }


}