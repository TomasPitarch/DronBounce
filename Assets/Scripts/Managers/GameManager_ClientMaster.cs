using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class GameManager_ClientMaster : MonoBehaviourPunCallbacks
{
    GameManager_Client GM_Client;

    [SerializeField]
    BallSpawner myBallSpawner;

    [SerializeField]
    public ScoreManager_ClientMaster myScoreManager;


    [SerializeField]
    int MaxPlayerAllowed;

    public Dictionary<int,Player> PlayersOrders;
    List<Player> ActivePlayers;
   
    void Awake()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Destroy(this);
        }
        GM_Client = GetComponent<GameManager_Client>();
        PlayersOrders = new Dictionary<int, Player>();
        ActivePlayers = new List<Player>();
        OnPlayerEnteredRoom(PhotonNetwork.LocalPlayer);
        
    }
    void Start()
    {
        myScoreManager.OnLose += PlayerLose;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
    void PlayerLose(int order)
    {
        myScoreManager.EndTriggerFunction(order);

        if (PlayersOrders.ContainsKey(order))
        {
            Player loserPlayer = PlayersOrders[order];
            GM_Client.PlayerLose(loserPlayer);

            ActivePlayers.Remove(loserPlayer);
        }

        WinnerCheck();

    }

    void WinnerCheck()
    {
        Debug.Log("winnercheck");

        if (ActivePlayers.Count==1)
        {
            Player winnerPlayer = ActivePlayers[0];
            GM_Client.PlayerWin(winnerPlayer);
            Debug.Log("We have a winner");
            EndGame();
        }
    }

    void StartGame()
    {
        SpawnTank();
        myBallSpawner.NextBall();
        myScoreManager.SetInitialScores();
    }
    void EndGame()
    {
        Debug.Log("GM/clientmaster/endgame()");
        myBallSpawner.EndGame();
    }

    void SpawnTank()
    {
        PhotonNetwork.Instantiate("Tank", new Vector3(-1, 0.4f, 0.3f)
        , Quaternion.identity);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PlayersOrders.Add(PhotonNetwork.CurrentRoom.PlayerCount - 1, newPlayer);

            ActivePlayers.Add(newPlayer);

            var order = PhotonNetwork.CurrentRoom.PlayerCount;

            if (order == MaxPlayerAllowed)
            {
                StartGame();
                PhotonNetwork.CurrentRoom.IsOpen = false;

                Debug.Log("cerramos cupos");
            }
        }
           

        
    }
   
}
