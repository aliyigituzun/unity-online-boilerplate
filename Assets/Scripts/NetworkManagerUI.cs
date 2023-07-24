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
    [SerializeField] private GameObject CharacterSelectorOpenButton;
    [SerializeField] private GameObject CharacterSelectorPanel;
    [SerializeField] private GameObject Character1Button;
    [SerializeField] private GameObject Character2Button;

    [SerializeField] private GameObject Player;
    
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
        CharacterSelectorOpenButton.SetActive(false);
        CharacterSelectorPanel.SetActive(false);
    }

    public void ShowButtons(){
        IpField.SetActive(true);
        ClientButton.SetActive(true);
        HostButton.SetActive(true);  
        ServerButton.SetActive(true);
        CharacterSelectorOpenButton.SetActive(true);
        CharacterSelectorPanel.SetActive(true);
    }

    public void Disconnect(){
        NetworkManager.Singleton.Shutdown();
        Debug.Log("Disconnect");
        ShowButtons();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void ClientStart(){

        NetworkManager.Singleton.StartClient();
        Debug.Log("Client");
        HideButtons();
    }


    public void HostStart(){

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
        Player.transform.GetChild(1).gameObject.SetActive(false);
        Player.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SelectCharacter2()
    {
        Debug.Log("1");
        Player.transform.GetChild(0).gameObject.SetActive(false);
        Player.transform.GetChild(1).gameObject.SetActive(true);

    }







}