using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RayEnemyAttackModule : EnemyAttackModule
{

    public UnityEvent OnPlayerDetected;


    bool detectedPlayer = false;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        RaycastHit2D[] result = null;
        result = Physics2D.BoxCastAll(transform.position, new Vector2(1f, 1f), 0, Vector2.down, 5);
        
        foreach(RaycastHit2D hit in result)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if(!detectedPlayer)
                {
                    detectedPlayer = true;
                    OnPlayerDetected?.Invoke();
                }
                if (timer >= delay)
                {
                    timer = 0;
                    switch (attackType)
                    {
                        case AttackType.Forward:
                            Shoot();
                            break;
                        case AttackType.AimPlayer:
                            Shoot(GetPlayerDir());
                            break;
                        case AttackType.Circle:
                            CircleShoot();
                            break;
                    }

                }
            }
        }
        
         
    }
}
