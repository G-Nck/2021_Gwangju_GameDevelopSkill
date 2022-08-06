using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttackModule : AttackModule
{
    public Projectile[] bulletByLevel;

    public float atkSpeed = 1;

    public int atkLevel;



    public float buffTimer;



    public float delay;
    private float timer = 0;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        atkLevel = 0;
        bullet = bulletByLevel[atkLevel];
    }


    public UnityEvent OnAttackLevelUp;

    public void AttackLevelUp()
    {
        OnAttackLevelUp?.Invoke();
        atkLevel = Mathf.Min(atkLevel + 1, 4);
        bullet = bulletByLevel[atkLevel];
    }


    public void TryShoot()
    {
        if(timer > delay / atkSpeed)
        {
            Shoot();
            timer = 0;
        }
    }

    public override void Shoot()
    {
        OnShoot?.Invoke();
        Projectile proj = Instantiate(bullet, transform.position, transform.rotation);
        proj.damage = character.ATK * (buffTimer > 0 ? 2 : 1);
        proj.team = character.team;

    }


    public ParticleSystem buffVFX;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        buffTimer -= Time.deltaTime;
        buffVFX.gameObject.SetActive(buffTimer > 0);


    }
}
