using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogginView : MonoBehaviour
{
    [SerializeField] Button connectButton;
    [SerializeField] LogginManager myLogginManager;

    [SerializeField] TMP_InputField roomName;
    [SerializeField] TMP_InputField playerName;



    bool isConnected;
    // Start is called before the first frame update
    void Start()
    {
        isConnected = false;
         
        connectButton.interactable = false;
        myLogginManager.OnJoniedLobbyEvent += OnJoinedLobby;

        //Linea de codigo a reponer sin autoconect autoconnect//
        myLogginManager.OnConnectEvent += OnConnectPress;
    }
    private void Update()
    {
        CheckForConnectButton();

        ////Funcion de autoconnect//
        //AutoLoad();
    }

    void CheckForConnectButton()
    {
      
        if (roomName.text != "" && playerName.text != "" && isConnected)
        {
            connectButton.interactable = true;

        }
        else
        {
            connectButton.interactable = false;
        }
    }

    public void OnJoinedLobby()
    {
        isConnected = true;
    }
    public void OnConnectPress()
    {
        myLogginManager.LoadRoomAndName(roomName.text,playerName.text);
    }

    public void AutoLoad()
    {
        myLogginManager.LoadRoomAndName("1", "AzedoR");
        Debug.Log("Autoload");

        if (isConnected)
        {
            myLogginManager.Connect();
        }
       
        
    }

}
