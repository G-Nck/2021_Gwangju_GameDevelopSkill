using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Character
{

    public float godTimer;
    public float godEffectTimer;
    public float hitTimer;


    LivingEntity livingEntity;

    PlayerController playerController;

    Animator animator;


    public GameData gameData;

    private int bombCount;
    public int BombCount
    {
        get { return bombCount; }
        set { bombCount = Mathf.Clamp(value, 0, 3); }
    }

    private int ultimateCount;
    public int UltimateCount
    {
            get { return ultimateCount; }
            set
        {
            ultimateCount = Mathf.Clamp(value, 0, 3);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        livingEntity = GetComponent<LivingEntity>();

        ATK = gameData.playerATK;
        livingEntity.Def = gameData.playerDEF;

    }

    void Start()
    {
        GameManager.instance.player = this;

    }

    int godPropID = Animator.StringToHash("God");
    int hitPropID = Animator.StringToHash("Hit");

    // Update is called once per frame
    void Update()
    {
        godTimer -= Time.deltaTime;
        godEffectTimer -= Time.deltaTime;
        hitTimer -= Time.deltaTime;

        livingEntity.isGod = godTimer > 0 || hitTimer > 0;

        animator.SetBool(godPropID, godEffectTimer > 0);
        animator.SetBool(hitPropID, hitTimer > 0);

    }



    public void PlayerStageOneStart()
    {
        StopCoroutine(nameof(PlayerStage1Start));
        StartCoroutine(nameof(PlayerStage1Start));
    }


    IEnumerator PlayerStage1Start()
    {
        float timer = 2;
        Vector3 viewPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f));
        viewPos.z = 0;
        transform.position = viewPos;
        playerController.enabled = false;
        while(timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            transform.Translate(Vector2.up * Time.fixedDeltaTime * 2);
            yield return new WaitForFixedUpdate();
        }
        playerController.enabled = true;

    }

    public void PlayerStageTwoStart()
    {
        Vector3 viewPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.2f));
        viewPos.z = 0;
        transform.position = viewPos;
    }

    public void GetScoreByHealth()
    {
        GameManager.instance.score += livingEntity.CurrentHP * 10;
    }


    public UnityEvent OnGodActive;

    public void SetPlayerGod()
    {
        OnGodActive?.Invoke();
        godTimer = Mathf.Infinity;
        godEffectTimer = Mathf.Infinity;
    }

    public void ResetPlayerGod()
    {
        godTimer = 0;
        godEffectTimer = 0;
        hitTimer = 0;
    }


    public void OnPlayerGetGodItem()
    {
        OnGodActive?.Invoke();
        //치트키로 인해 godTimer가 너무 높을 경우 무적을 변경하지 않음.
        if (godTimer > 10000) return;
        godTimer = 3;
        godEffectTimer = 2.5f;
    }

    public void OnPlayerHit()
    {
        hitTimer = 1.5f;
    }


    public void OnPlayerDead()
    {
        GameManager.instance.GameOver();
    }
}
