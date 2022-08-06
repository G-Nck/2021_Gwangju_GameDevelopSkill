using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPattern : AttackModule
{

    public Transform[] spawnPos;
 
    public Enemy[] spawnEnemy;

    public float delay;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delay)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        Enemy selectedEnemy = spawnEnemy[Random.Range(0, spawnEnemy.Length)];

        foreach (Transform pos in spawnPos)
        {
            

            Enemy cloned = Instantiate(selectedEnemy, pos.transform.position, pos.transform.rotation);
            cloned.GetComponent<LivingEntity>().isClone = true;
            cloned.GetComponent<MoveModule>().SetSpeed();
            cloned.StartSpawnAnim();
        }
    }
}
