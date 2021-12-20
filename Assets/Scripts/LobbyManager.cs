using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    List<TextMeshProUGUI> ListOfNickNames;

    [SerializeField]
    Button StartButton;

    [SerializeField]
    TextMeshProUGUI RoomName;

    private void Awake()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Destroy(StartButton.gameObject);
            return;
        }
        SetPlayer(0,PhotonNetwork.LocalPlayer.NickName);
    }
    private void Start()
    {
        RoomName.text += PhotonNetwork.CurrentRoom.Name;
    }
    void SetPlayer(int order,string playerNickName)
    {

        ListOfNickNames[order].text = playerNickName;
    }

    [PunRPC]
    void SetNames(string NickNames)
    {
        var stringArray = NickNames.Split('/');

        for(int i=0;i<stringArray.Length-1;i++)
        {
            ListOfNickNames[i].text = stringArray[i];
        }
    }

    [PunRPC]
    void LoadGameScene()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        var orderPlayer = (PhotonNetwork.PlayerList.Length)-1;
        var nickName = newPlayer.NickName;

        SetPlayer(orderPlayer, nickName);

        UpdateNickNamesList();
    }
    private void UpdateNickNamesList()
    {
        var stringUpdate = "";

        foreach(var str in ListOfNickNames)
        {
            stringUpdate += str.text + "/";
        }
        Debug.Log(stringUpdate);

        photonView.RPC("SetNames",RpcTarget.Others,stringUpdate);
    }
    public void StartGame()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;

        photonView.RPC("LoadGameScene",RpcTarget.All);
        
    }
}
