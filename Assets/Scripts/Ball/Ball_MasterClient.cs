using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Ball_MasterClient : MonoBehaviourPun
{
    public event Action<Ball_MasterClient> OnBallsRelease = delegate { };

    [SerializeField]
    float initialForce;

    Rigidbody myRB;

    Ball_Client localBall;

    

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();

        if (!PhotonNetwork.IsMasterClient)
        {
            Destroy(myRB);
            Destroy(this);
        }

        localBall = GetComponent<Ball_Client>();
    }
       
    public void Init(Vector3 startPosition)
    {
        gameObject.SetActive(true);
        myRB.velocity = (GetRandomDirection() * initialForce);
    }

    private void Update()
    {
            myRB.velocity = myRB.velocity.normalized * initialForce;
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
        localBall.photonView.RPC("ClientRelease", RpcTarget.All);
    }
    public void BallEndGameDestruction()
    {
        Debug.Log("ball_Clientmaster/Ballendgamedestruction");
        localBall.photonView.RPC("ClientRelease", RpcTarget.All);
    }
    private void OnCollisionEnter(Collision collision)
    {
        localBall.photonView.RPC("OnCollisionEffect",RpcTarget.All);
    }
    private void OnCollisionExit(Collision collision)
    {
            if (collision.gameObject.tag == "Floor")
            {
                myRB.constraints = RigidbodyConstraints.FreezePositionY;
                transform.position = new Vector3(transform.position.x, 0.25f, transform.position.z);
            }
    }
}
