using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Ball_Client : MonoBehaviourPun
{
    
    [SerializeField]
    GameObject SparkEffect;

    [SerializeField]
    string BounceSound;

    

    [PunRPC]
    public void ClientRelease()
    {
        Debug.Log("ball_client/ClientRelease");
        Destroy(this.gameObject);
    }

    [PunRPC]
    public void OnCollisionEffect(/*Collision collision*/)
    {

        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;

        //Instantiate(SparkEffect, pos, rot);

        Instantiate(SparkEffect, transform.position,Quaternion.identity);
        SoundManager.Play(BounceSound);
    }
}
