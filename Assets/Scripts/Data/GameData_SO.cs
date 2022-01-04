using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameDataScriptableObject", order = 1)]

public class GameData_SO : ScriptableObject
{
    public int ScoreToLose;
    public int FreezeTime;
       
   
}
