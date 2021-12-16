using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    Character myCharacter;
   
    private void Update()
    {
        if(myCharacter==null)
        {
            return;
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Movimiento a la derecha
            myCharacter.MoveRight();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Movimiento a la izquierda
           myCharacter.MoveLeft();
           
        }

        if (!(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ||
           Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ||
           Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Alpha1)))
        {
            myCharacter.Idle();

        }


        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    //Movimiento a la derecha
        //    myCharacter.EndMoveRight();
        //}
        //else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    //Movimiento a la izquierda
        //    myCharacter.EndMoveLeft();

        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //Captura Pelotas
        //    myCharacter.HoldBall();
        //}

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    //Larga la pelota
        //    myCharacter.ReleaseBall();
        //}

        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    //Emote
        //    myCharacter.Emote();
        //}







    }
    public void SetCharacter(Character characterToSet)
    {
        myCharacter= characterToSet;
    }
    public void RigthButton()
    {
        myCharacter.MoveRight();
    }
    public void LeftButton()
    {
        myCharacter.MoveLeft();
    }
}
