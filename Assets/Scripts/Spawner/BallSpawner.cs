using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallSpawner : MonoBehaviour
{

    public event Action OnGameEnd/*=delegate { }*/;

    [SerializeField]
    string ballPrefabName;

    [SerializeField]
    int maxBalls;
      

    public int liveBalls=0;


    
    private void Awake()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Destroy(this);
        }
    }

    public void EndGame()
    {
        Debug.Log("BAllspawner/endgame");
        OnGameEnd();
        StopAllCoroutines();
    }

    void Spawn()
    {
        var ball= PhotonNetwork.Instantiate(ballPrefabName, Vector3.zero, Quaternion.identity).GetComponent<Ball_MasterClient>();


        ball.GetComponent<Ball_MasterClient>().Init(transform.position);


        OnGameEnd += ball.GetComponent<Ball_MasterClient>().BallEndGameDestruction;
        

        ball.GetComponent<Ball_MasterClient>().OnBallsRelease += DieBall;
    }
      
    void DieBall(Ball_MasterClient ballReference)
    {
        liveBalls--;
        OnGameEnd-= ballReference.GetComponent<Ball_MasterClient>().BallEndGameDestruction;
        NextBall();
    }

    IEnumerator SpawnBall(int elapsedTime)
    {
        liveBalls++;
        yield return new WaitForSeconds(elapsedTime);
        Spawn();
        NextBall();
    }
    public void NextBall()
    {
        if(liveBalls<maxBalls)
        {
            var randomInt = UnityEngine.Random.Range(3, 6);
            
            StartCoroutine("SpawnBall", randomInt);
        }
    }
}
