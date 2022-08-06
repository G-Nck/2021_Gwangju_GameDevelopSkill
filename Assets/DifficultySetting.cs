using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetting : MonoBehaviour
{

    public ClassData classData;
    public GameData gameData;
    


    public void SetEasy()
    {
        gameData.playerDEF = classData.easyDEF;
        gameData.playerATK = classData.easyDamage;
    }

    public void SetNormal()
    {
        gameData.playerDEF = classData.normalDEF;
        gameData.playerATK = classData.normalDamage;
    }

    public void SetHard()
    {
        gameData.playerDEF = classData.hardDEF;
        gameData.playerATK = classData.hardDamage;
    }
}
