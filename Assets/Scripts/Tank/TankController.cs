using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TankController : MonoBehaviour
{
    Transform[] waypoints;
    int current = 0;
    float waypointRadius = 1;

    Tank myTank;

    private void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Destroy(this);
        }

        myTank = GetComponent<Tank>();
        SetWayPoints();
    }
   
    void Update()
    {
       myTank.Move(GetDestination());
    }
    public Vector3 GetDestination()
    {
        if (Vector3.Distance(waypoints[current].position, transform.position) < waypointRadius)
        {
            current = UnityEngine.Random.Range(0, waypoints.Length);
        }
       return waypoints[current].position;

    }
    private void SetWayPoints()
    {
        var gameobject = GameObject.Find("Waypoints");
        waypoints = gameobject.GetComponentsInChildren<Transform>();

    }
}
