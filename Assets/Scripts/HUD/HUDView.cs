using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System;
using TMPro;

public class HUDView : MonoBehaviourPun
{
    [SerializeField]
    Text roomText;

    [SerializeField]
    TextMeshProUGUI resultText;

    [SerializeField]
    Button ReLogButton;

    [SerializeField]
    GameManager_ClientMaster myGM;

    [SerializeField]
    List<Text> ScoreVList;

    [SerializeField]
    List<Text> ScoreVNames;


    private void Awake()
    {
        myGM.myScoreManager.OnScoreGoal += RefreshScores;
    }
    void Start()
    {
        roomText.text ="Sala:"+ PhotonNetwork.CurrentRoom.Name;
        
        resultText.gameObject.SetActive(false);
    }

    void RefreshScores(int PlayerOrder, int newScore)
    {
           if(myGM.PlayersOrders.ContainsKey(PlayerOrder))
           {
                photonView.RPC("SendRefreshScores", RpcTarget.All, PlayerOrder, myGM.PlayersOrders[PlayerOrder].NickName, newScore);
           }
           else
           {
                photonView.RPC("SendRefreshScores", RpcTarget.All, PlayerOrder,PlayerOrder.ToString(), newScore);
           }
    }

    [PunRPC]
    void SendRefreshScores(int PlayerOrder,string playername, int newScore)
    {
       if (playername=="")
       {
            ScoreVList[PlayerOrder].text = ("Player" + PlayerOrder + ":" + newScore);

       }
       else
       {
            ScoreVList[PlayerOrder].text = newScore.ToString();
            ScoreVNames[PlayerOrder].text = playername;
       }

    }
    public void WinHUD()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "Ganaste";
        resultText.color = Color.green;

        ReLogButton.gameObject.SetActive(true);


    }
    public void LoseHUD()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "Perdiste";
        resultText.color = Color.red;

        ReLogButton.gameObject.SetActive(true);
    }

    //void SetScoresAtStart()
    //{
    //    Debug.Log("seteo de scores vuelta:");
    //    for (int i=0;i<ScoreVList.Count;i++)
    //    {
    //        Debug.Log("seteo de scores vuelta:" + i);
    //        RefreshScores(i, myGM.myScoreManager.DefaultGoal);
    //    }
    //}
}
