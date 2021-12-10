using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Tank : MonoBehaviour
{
    public event Action OnMove = delegate{ };
    public event Action OnHit = delegate { };


    float rotSpeed;
    public float speed;

    Rigidbody myRB;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            Destroy(myRB);
        }
    }

    public void Move(Vector3 destination)
    {
        OnMove();
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);

    }

   public void RecieveHit()
    {
        OnHit();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ball")
        {
            RecieveHit();
        }
    }


}
