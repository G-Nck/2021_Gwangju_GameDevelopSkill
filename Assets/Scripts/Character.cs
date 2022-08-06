using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(LivingEntity))]
public class Character : MonoBehaviour
{
    public enum Team
    {
        Enemy,
        Player,
        Third
    }

    public Team team;

    public float MaxHP;
    public float ATK;

    public float ScoreAmount;

    public void AttackStage()
    {
        StageManager.instance.currentStage.PainGauge += ATK / 2;
    }

    public void GetScore()
    {
        GameManager.instance.score += ScoreAmount;
    }


}
