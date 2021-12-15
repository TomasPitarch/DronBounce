using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    Animator myAnim;
    Character myChar;

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        myChar = GetComponent<Character>();

        //Suscripcion a los eventos del Char//
        myChar.OnLeftMove += LeftMoveAnimation;
        myChar.OnRigthMove += RigthMoveAnimation;
        myChar.OnIddle += IdleAnimation;

    }

    void RigthMoveAnimation()
    {
        //Debug.Log("animamos a la derecha");
        myAnim.SetBool("Idle", false);

        myAnim.SetBool("MovingLeft", false);

        myAnim.SetBool("MovingRigth",true);

       
    }
    void LeftMoveAnimation()
    {
        //Debug.Log("animamos a la izquierda");

        myAnim.SetBool("Idle", false);

        myAnim.SetBool("MovingRigth", false);

        myAnim.SetBool("MovingLeft",true);
       
    }
    void IdleAnimation()
    {
        //Debug.Log("Idle");

        myAnim.SetBool("MovingRigth", false);
        myAnim.SetBool("MovingLeft", false);

        myAnim.SetBool("Idle",true);
    }
}


