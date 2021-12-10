using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;

public class LogginManager : MonoBehaviourPunCallbacks
{
    public event Action OnJoniedLobbyEvent = delegate{};
    public event Action OnConnectEvent = delegate { };

    string roomName;
    string playerName;

    [SerializeField] string roomSceneName;


    private void Start()
    {
        Debug.Log("starte del logginmanager");
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect()
    {
        //Linea a recuperar sin el autoconnect
        OnConnectEvent();
        RoomOptions options = new RoomOptions();
        options.IsOpen = true;
        options.MaxPlayers = 4;

        PhotonNetwork.NickName = playerName;
        
        PhotonNetwork.JoinOrCreateRoom(roomName,options,TypedLobby.Default);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        
       
        Debug.Log("OnConnectedToMaster");
    }
    public override void OnJoinedLobby()
    {
        OnJoniedLobbyEvent();
        //Debug.Log("OnJoinedLobby");
    }
    public override void OnConnected()
    {
        //Debug.Log("OnConnected");
    }
    public override void OnCreatedRoom()
    {
        //Debug.Log("OnCreatedRoom");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        //Debug.Log("fail on create room");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        //Debug.Log("fail on join room");
    }
    public override void OnJoinedRoom()
    {
        //Debug.Log("on joined room:"+PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel(roomSceneName);
    }
    public void LoadRoomAndName(string room,string player)
    {
        roomName = room;
        playerName = player;
    }

    
}
