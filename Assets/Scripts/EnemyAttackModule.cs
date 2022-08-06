using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackModule : AttackModule
{
    public enum AttackType
    {
        Forward,
        AimPlayer,
        Circle
    }


    public AttackType attackType;

    public float delay;
    protected float timer = 0;

    public float randomOffset;
    public float offset;


    public int bulletCount;

    Player player => GameManager.instance.player;

    public override void Start()
    {
        base.Start();
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
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

    public override void Shoot()
    {
        OnShoot?.Invoke();

        Projectile proj = Instantiate(bullet, transform.position, transform.rotation * Quaternion.AngleAxis(offset + Random.Range(-randomOffset, randomOffset), Vector3.forward));
        proj.damage = character.ATK;
        proj.team = character.team;
    }

    public void Shoot(Quaternion rot, bool playSFX = true)
    {
        if(playSFX) OnShoot?.Invoke();
        Projectile proj = Instantiate(bullet, transform.position, rot);
        proj.damage = character.ATK;
        proj.team = character.team;

    }

    public Quaternion GetPlayerDir()
    {
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

        return Quaternion.AngleAxis(angle - 90 + offset + Random.Range(-randomOffset, randomOffset), Vector3.forward);

    }


    public void CircleShoot()
    {
        OnShoot?.Invoke();

        float startOffset = Random.Range(-randomOffset, randomOffset);

        for(int i = 0; i < bulletCount; i++)
        {
            Shoot(Quaternion.AngleAxis((360 / bulletCount) * i + startOffset, Vector3.forward), false);
            
        }
    }

}
