using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : Enemy
{
    public string enemyName;

    public bool isOrigin;

    Animator animator;

    LivingEntity livingEntity;


    public UnityEvent OnDivided;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        livingEntity = GetComponent<LivingEntity>();
    }


    // Update is called once per frame
    void Update()
    {
        if (livingEntity.CurrentHP / livingEntity.MaxHP <= 0.5f)
        {
            Divide();
        }
    }
    bool isdivided = false;

    private void OnEnable()
    {
        isdivided = false;   
        DisplayUI();

        GetComponent<Animator>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<BossAttackPattern>().enabled = true;

    }

    public void Divide()
    {
        if (!isOrigin || isdivided) return;
        isdivided = true;
        animator.SetTrigger("Divide");
        OnDivided?.Invoke();
    }



    public void RemoveUI()
    {
        UIManager.instance.bossUITarget.Remove(this);

    }

    public void DisplayUI()
    {
        if(!UIManager.instance.bossUITarget.Contains(this))
            UIManager.instance.bossUITarget.Add(this);

    }

    public void Appear()
    {
        gameObject.SetActive(true);
        DisplayUI();
    }

    public Boss[] divided;

    public void CheckDivided()
    {
        bool survived = false;

        foreach(Boss boss in divided)
        {
            if (boss.GetComponent<LivingEntity>().isDead == false) survived = true;
        }

        if (survived == false) ClearStage();
    }

    public void ClearStage()
    {
        Debug.Log("º¸½º Á×´ÂÁß");
        Invoke("NextStage", 3);
    }

    public void NextStage()
    {
        StageManager.instance.currentStage.ClearStage();
    }


    public ParticleSystem deathVFX;

    public void SpawnVFX()
    {
        Instantiate(deathVFX, transform.position, transform.rotation);
    }

    private void OnDisable()
    {
        RemoveUI();
    }

    


}
