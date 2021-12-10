using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ScoreManager_Client : MonoBehaviourPun
{
   
    public List<ScoreTrigger> TirggerList;

    [PunRPC]
    public void EndTrigger(int order)
    {
        TirggerList[order].ChangeTriggerToWall();
    }

    [PunRPC]
    public void LigthsOnScore(int order)
    {
        TirggerList[order].LigthOnScore();
    }
}
