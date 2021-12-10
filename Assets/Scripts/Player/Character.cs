using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event Action OnRigthMove = delegate { };
    public event Action OnLeftMove = delegate { };
    public event Action OnIddle = delegate { };


    [SerializeField]
    float movementSpeed;

    [SerializeField]
    MovementSensor left;

    [SerializeField]
    MovementSensor rigth;

    Rigidbody myRB;
    
    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    public void SetDirectionToCenter(int SpawnPosition)
    {
        transform.eulerAngles = new Vector3(0, SpawnPosition * -90, 0);
    }

    public void MoveLeft()
    {
        if (left.CanMove)
        {
            OnLeftMove();
            transform.position += transform.right * (-movementSpeed * Time.deltaTime);
        }
    }

    public void MoveRight()
    {
        if (rigth.CanMove)
        {
            OnRigthMove();
            transform.position += transform.right * (movementSpeed * Time.deltaTime);
        }
    }

    public void HoldBall()
    {

    }

    public void ReleaseBall()
    {

    }

    internal void Emote()
    {
        throw new NotImplementedException();
    }

    internal void Idle()
    {
        OnIddle();
    }
}
