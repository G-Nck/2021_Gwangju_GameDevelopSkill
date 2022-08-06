using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackModule : MonoBehaviour
{
    public Projectile bullet;

    public Character character;


    public UnityEvent OnShoot;

    public virtual void Start()
    {
        if(character == null) character = GetComponent<Character>();      
    }


    public virtual void Shoot()
    {
        OnShoot?.Invoke();
        Projectile proj = Instantiate(bullet, transform.position, transform.rotation);
        proj.damage = character.ATK;
        proj.team = character.team;
        
    }

}
