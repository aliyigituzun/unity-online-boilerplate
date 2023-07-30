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

    [SerializeField] private GameObject Character1;
    [SerializeField] private GameObject Character2;

    int CharacterSelected;

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
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("heyo");
            CharacterSelected = 1;
            Debug.Log(CharacterSelected + "ahanda bu");
        }
    }
    [ServerRpc(RequireOwnership = false)]
    private void SpawnPlayerServerRpc(ulong clientId)
    {
            GameObject newPlayer;
            NetworkObject netObj;
            if (CharacterSelected == 0)
            {
                Debug.Log("1Char");
                newPlayer = (GameObject)Instantiate(Character1);
            }
            else
            {
                Debug.Log("2Char");
                newPlayer = (GameObject)Instantiate(Character2);
            }
            netObj = newPlayer.GetComponent<NetworkObject>();
            netObj.SpawnAsPlayerObject(clientId, true);
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

    public override void OnNetworkSpawn()
    {
        Debug.Log("OnNetworkSpawn Triggered");
        SpawnPlayerServerRpc(NetworkManager.Singleton.LocalClientId);
        
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
        Debug.Log("1 Selected");
        CharacterSelected = 0;
    }
    public void SelectCharacter2()
    {
        Debug.Log("2 Selected");
        CharacterSelected = 1;
    }


}