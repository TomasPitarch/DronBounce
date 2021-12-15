using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Ball : MonoBehaviourPun
{
    public event Action<Ball> OnBallsRelease = delegate { };

    Rigidbody myRB;

    [SerializeField]
    float initialForce;

    [SerializeField]
    GameObject SparkEffect;

    [SerializeField]
    string BounceSound;


    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();

        //Si no soy el server, destruyo el Collider//

        if(!PhotonNetwork.IsMasterClient)
        {
            var collider = GetComponent<SphereCollider>();
            if(collider!=null)
            {
                Destroy(GetComponent<SphereCollider>());
            }
            
        }
    }
  
    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            myRB.velocity = myRB.velocity.normalized * initialForce;
        }
    }
    public void Init(Vector3 startPosition)
    {
        gameObject.SetActive(true);
        myRB.velocity = (GetRandomDirection() * initialForce);
    }
    Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f),
                           0,
                           UnityEngine.Random.Range(-1.0f, 1.0f)
                           );
    }
    public void BallRelease()
    {
        OnBallsRelease(this);
        PhotonNetwork.Destroy(photonView);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        photonView.RPC("OnCollisionEffect",RpcTarget.All);
    }
    void OnCollisionExit(Collision collision)
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        if (collision.gameObject.tag == "Floor")
        {
            myRB.constraints = RigidbodyConstraints.FreezePositionY;
            transform.position = new Vector3(transform.position.x, 0.25f, transform.position.z);
        }
    }


    #region RPCs
    [PunRPC]
    public void OnCollisionEffect()
    {
        Instantiate(SparkEffect, transform.position, Quaternion.identity);
        SoundManager.Play(BounceSound);
    }
    #endregion
}
