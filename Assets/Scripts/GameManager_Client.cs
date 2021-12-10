using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager_Client : MonoBehaviourPun
{

    [SerializeField]
    HUDView myHUD;

    //[SerializeField]
    //public ScoreManager_ClientMaster myScoreManagerClientMaster;


    public void PlayerLose(Player loserPlayer)
    {
        Debug.Log("HUD/Player Lose");
        photonView.RPC("SetLoserClient",loserPlayer);
    }
    public void PlayerWin(Player winnerPlayer)
    {
        photonView.RPC("SetWinnerClient", winnerPlayer);
    }

    [PunRPC]
    void SetLoserClient()
    {
        myHUD.LoseHUD();
    }

    [PunRPC]
    void SetWinnerClient()
    {
        myHUD.WinHUD();
    }

    public void ToLogginScene()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Loggin");
    }
}
