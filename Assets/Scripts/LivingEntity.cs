using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivingEntity : MonoBehaviour
{
    Character character;

    public bool isClone = false;

    public bool isDead = false;

    public float MaxHP;
    private float currentHP;
    public float CurrentHP
    {
        get { return currentHP; }
        set { currentHP = Mathf.Clamp(value, 0, MaxHP); }
    }

    public float Def = 1;

    public bool isGod = false;

    [HideInInspector]
    public Character.Team team;


    public UnityEvent OnHit;
    public UnityEvent OnDie;


    public bool shouldBodyDamage;
    public bool shouldGetBodyDamage;

    private void Awake()
    {
        character = GetComponent<Character>();

    }

    void Start()
    {
        MaxHP = character.MaxHP;
        team = character.team;
        CurrentHP = MaxHP;
    }

    public void ResetEntity()
    {
        CurrentHP = MaxHP;
        isDead = false;
    }

    public bool attackedThisFrame = false;

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        attackedThisFrame = false;

    }

    public void GetDamage(float damage)
    {
        attackedThisFrame = true;

        CurrentHP -= damage * Def;
        OnHit?.Invoke();

        if(currentHP <= 0)
        {
            Die();
        }
    }

    private void OnEnable()
    {
        ResetEntity();
    }
    public void Die()
    {
        if (isDead) return;
        isDead = true;
        OnDie?.Invoke();
        if (isClone) Destroy(gameObject);
        if (delayDeath) Invoke(nameof(DelayDeath), deathTimer);
        else
        {
            gameObject.SetActive(false);

        }
    }


    void DelayDeath()
    {

        gameObject.SetActive(false);
    }
    

    public bool delayDeath;
    public float deathTimer;

    public void SpawnDeathVFX()
    {
        Instantiate(deathVFX, transform.position, transform.rotation);
    }

    public ParticleSystem deathVFX;


    public bool isWhiteCell;

    public bool isRedCell;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out LivingEntity entity))
        {
            if(entity.team != this.team)
            {
                if (entity.shouldGetBodyDamage && shouldGetBodyDamage) return;
                else if (shouldGetBodyDamage)
                {
                    if(isRedCell)
                    {
                        if (entity.gameObject.CompareTag("Player")) GetDamage(1);

                    }
                    else
                    {
                        GetDamage(1);
                    }
                }

                if (entity.isGod) return;

                if (shouldBodyDamage)
                {
                    if (gameObject.CompareTag("Player") && entity.isRedCell) entity.GetDamage(character.ATK / 2);
                    else if (!gameObject.CompareTag("Player") && entity.isRedCell) return;
                    else entity.GetDamage(character.ATK / 2);
                }
            }
        }
    }
}
