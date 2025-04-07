using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct GameStatus_SO 
{
    [Header("Save File Data")]
    public int enemyCount;
    public int heat;
}

[CreateAssetMenu(fileName = "SaveSO", menuName = "Scriptable Objects/SaveSO")]
public class SaveSO : ScriptableObject
{
    public GameStatus_SO gameStatus;
    
    
   
    public void PrepareLevel()
    {
        int level=GameObject.Find("Save Handler").GetComponent<SaveSystem>().gameStatus.level;
        if(level==1)
        {
            gameStatus.enemyCount=1;
            gameStatus.heat=1;
        }
        else if(level==2)
        {
            gameStatus.enemyCount=2;
            gameStatus.heat=1;
        }
        else if(level==3)
        {
            gameStatus.enemyCount=2;
            gameStatus.heat=2;
        }
        else if(level==4)
        {
            gameStatus.enemyCount=3;
            gameStatus.heat=2;
        }
        else if(level==5)
        {
            gameStatus.enemyCount=3;
            gameStatus.heat=3;
        }
        Debug.Log ("Level "+level+" ready");
    }

    
}
