using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode.Transports.UTP;

public class NetworkManagerUI : NetworkBehaviour
{


    [SerializeField] private GameObject ServerButton;
    [SerializeField] private GameObject HostButton;
    [SerializeField] private GameObject ClientButton;
    [SerializeField] private GameObject IpField;
    [SerializeField] private GameObject ThisNetworkManager;
    [SerializeField] private GameObject CharacterSelectorButton;
    [SerializeField] private GameObject CharacterSelectorPanel;
    [SerializeField] private GameObject Character1Button;
    [SerializeField] private GameObject Character2Button;

    [SerializeField] private GameObject gentleman;
    [SerializeField] private GameObject gnome;

    int CharacterSelection = 0; // 0 = gnome, 1 = gentleman

    private void Start()
    {
        CharacterSelectorPanel.SetActive(false);

    }

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


    public void ClientStart(){

        NetworkManager NetworkManagerScript = ThisNetworkManager.GetComponent<NetworkManager>();
        if (CharacterSelection == 0)
        {
            Debug.Log("gnome");
            NetworkManagerScript.NetworkConfig.PlayerPrefab = gnome;

        }
        if (CharacterSelection == 1)
        {
            Debug.Log("gentleman");
            NetworkManagerScript.NetworkConfig.PlayerPrefab = gentleman;
        }

        NetworkManager.Singleton.StartClient();
        Debug.Log("Client");
        HideButtons();
    }


    public void HostStart(){

        NetworkManager NetworkManagerScript = ThisNetworkManager.GetComponent<NetworkManager>();
        if (CharacterSelection == 0)
        {
            Debug.Log("gnome");
            NetworkManagerScript.NetworkConfig.PlayerPrefab = gnome;

        }
        if (CharacterSelection == 1)
        {
            Debug.Log("gentleman");
            NetworkManagerScript.NetworkConfig.PlayerPrefab = gentleman;
        }

        NetworkManager.Singleton.StartHost();
        Debug.Log("Host");
        HideButtons();
    }


    public void ServerStart(){
        NetworkManager.Singleton.StartServer();
        Debug.Log("Server");
        HideButtons();
    }


    public void Ip_Changed(string _ipe){
        UnityTransport thisisimportant = ThisNetworkManager.GetComponent<UnityTransport>();
        thisisimportant.ConnectionData.Address = _ipe;
    }

    public void OpenCharacterMenu()
    {
        CharacterSelectorPanel.SetActive(true);
    }
    public void CloseCharacterMenu()
    {
        CharacterSelectorPanel.SetActive(false);
    }

    public void SelectCharacter1()
    {
        Debug.Log("0");
        CharacterSelection = 0;
    }

    public void SelectCharacter2()
    {
        Debug.Log("1");
        CharacterSelection = 1;

    }







}