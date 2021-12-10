using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSensor : MonoBehaviour
{
    [SerializeField]
    string tagCompare;
    public bool CanMove;
    private void Start()
    {
        CanMove = true;
    }
   
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == tagCompare)
        {
            CanMove = false;
           
        }

    }
    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == tagCompare)
        {
           
            CanMove = true;
        }
    }
}
