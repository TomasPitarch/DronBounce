using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class FreezeCounter : MonoBehaviourPun
{
    [SerializeField]
    TextMeshProUGUI _TMP;

 
    public async Task StartCounter(int time)
    {
        _TMP.text = time.ToString();
        float i= time;

        while(i>0)
        {
            i-=Time.deltaTime;
            var newText = ((int)(i / 1)).ToString();
            photonView.RPC("UpdateView",RpcTarget.All,newText);
            await Task.Yield();

        }

        photonView.RPC("EndView",RpcTarget.All);
    }

   [PunRPC]
   void UpdateView(string number)
    {
        _TMP.text = number;
    }

    [PunRPC]
    void EndView()
    {
        Destroy(this.gameObject);
    }
}
