using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerNameView : MonoBehaviourPun
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    Text playerName;
    
    void Start()
    {
        //SetDirection();

        if (photonView.IsMine)
        {
            photonView.RPC("SetName", RpcTarget.AllBuffered, PhotonNetwork.NickName);
        }
       

    }
    private void LateUpdate()
    {
        canvas.transform.LookAt(canvas.transform.position+ Camera.main.transform.rotation*Vector3.forward,
                                Camera.main.transform.rotation*Vector3.up);
    }

    [PunRPC]
    void SetName(string name)
    {
        playerName.text = name;
    }
    
    //void SetDirection()
    //{
    //    canvas.transform.LookAt(Camera.main.transform);
    //}
}
