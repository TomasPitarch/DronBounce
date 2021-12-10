using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;
using Photon.Realtime;

public class ScoreManager_ClientMaster : MonoBehaviourPun
{
    //Events//
    public event Action<int, int> OnScoreGoal = delegate { };
    public event Action<int> OnLose = delegate { };


    [SerializeField]
    ScoreManager_Client MyScoreManager_Client;


    [SerializeField]
    int[] Scores = new int[4];

    [SerializeField]
    GameData_SO GameData;
    
    public int DefaultGoal;

   
   
    void Start()
    {
        MyScoreManager_Client = GetComponent<ScoreManager_Client>();

        ScoreTriggersOrderAsignation();
        TriggerListSuscription();

        DefaultGoal = GameData.ScoreToLose;
    }
    void TriggerListSuscription()
    {
        foreach (var v in MyScoreManager_Client.TirggerList)
        {
            v.OnScoreTrigger += ScoreGoal;
        }
    }
    public void SetInitialScores()
    {
        for (int i = 0; i < Scores.Length; i++)
        {
            Scores[i] = DefaultGoal;
            OnScoreGoal(i, DefaultGoal);
        }
    }

    internal void EndTriggerFunction(int order)
    {
        MyScoreManager_Client.photonView.RPC("EndTrigger", RpcTarget.All, order);
    }

    void ScoreTriggersOrderAsignation()
    {
        for (int i = 0; i < MyScoreManager_Client.TirggerList.Count; i++)
        {
            MyScoreManager_Client.TirggerList[i].Order = i;
        }

    }

    public void PlayerLose(int PlayerOrder)
    {
        MyScoreManager_Client.photonView.RPC("EndTrigger",RpcTarget.All,PlayerOrder);
    }

    public void AddPlayer(int PlayerOrder)
    {
        Scores[PlayerOrder]=DefaultGoal;
    }
    public void ScoreGoal(int PlayerOrder)
    {
        var newScore = Scores[PlayerOrder] -1;

        if(newScore<=0)
        {
            OnLose(PlayerOrder);
        }
       
        Scores[PlayerOrder] = newScore;

        MyScoreManager_Client.photonView.RPC("LigthsOnScore",RpcTarget.All,PlayerOrder);
        OnScoreGoal(PlayerOrder, newScore);


    }
   

    //Devuelve el orden del player ganador o -1 en caso de no haber terminado//
    public int WinnerOrder()
    {
        int order=-1;
        int i = 0;

        for (int j = 0; j< Scores.Length; j++)
        {
            Debug.Log("player "+j+" tiene de score:"+Scores[j]);
        }

        while(i<Scores.Length)
        {
            if (Scores[i]!=0 )
            {
                if (order == -1)
                {
                    order = i;
                }
                else
                {
                    return -1;
                }
            }
            i++;
        }
        return order;

    }

  


}
