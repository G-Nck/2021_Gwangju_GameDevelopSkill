using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPattern : MonoBehaviour
{
    public AttackModule[] attackModules;

    int patternIndex = 0;

    public float delay;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        timer = 0;
        patternIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delay)
        {
            timer = 0;
            if (patternIndex == attackModules.Length - 1)
            {
                patternIndex = 0;
            }
            else patternIndex++;

            foreach (AttackModule attackModule in attackModules)
            {
                attackModule.enabled = false;
            }

            attackModules[patternIndex].enabled = true;

        }
    }


    public void DisablePattern()
    {
        foreach (var attackModule in attackModules)
        {
            attackModule.enabled = false;
        }

        this.enabled = false;
    }
}
