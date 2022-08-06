using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image playerHPGauge;
    public Image stagePainGauge;

    public TMP_Text playerHPText;
    public TMP_Text stagePainText;

    public TMP_Text scoreText;

    private LivingEntity playerEntity;


    [Header("Boss UI")]
    public Image bossHpGauge;
    public TMP_Text bossNameText;
    public TMP_Text bossHealthText;

    public GameObject bossUI;

    public Animator animator;

    private void Awake()
    {
        instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        scoreFormat = scoreText.text;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPlayerHP();
        DisplayStagePain();
        DisplayScore();
        DisplayBoss();
    }


    public List<Boss> bossUITarget = new List<Boss>();

    public GameObject lowHPWarn;
    public GameObject highPainWarn;

    void DisplayBoss()
    {
        float maxHP = 0;
        float currentHP = 0;
        try
        {

            foreach(Boss boss in bossUITarget)
            {
                maxHP += boss.GetComponent<LivingEntity>().MaxHP;
                currentHP += boss.GetComponent<LivingEntity>().CurrentHP;
            }


            bossHpGauge.fillAmount = currentHP / maxHP;
            bossHealthText.text = "체력: "+Mathf.RoundToInt(currentHP / maxHP * 100)+"%";
            bossNameText.text = bossUITarget[0].enemyName;

            bossUI.SetActive(true);
        }

        catch
        {
            bossUI.SetActive(false);

        }
    }

    void DisplayPlayerHP()

    {
        try
        {
            playerHPGauge.fillAmount = playerEntity.CurrentHP / playerEntity.MaxHP;
            playerHPText.text = "체력: "+Mathf.FloorToInt(playerEntity.CurrentHP / playerEntity.MaxHP * 100) +"%";
            
            if(playerEntity.CurrentHP / playerEntity.MaxHP <= 0.33f) lowHPWarn.SetActive(true);
            else lowHPWarn.SetActive(false);

        }

        catch
        {
            playerEntity = GameManager.instance.player.GetComponent<LivingEntity>();
            playerHPGauge.fillAmount = playerEntity.CurrentHP / playerEntity.MaxHP;
            playerHPText.text = "체력: " + Mathf.FloorToInt(playerEntity.CurrentHP / playerEntity.MaxHP * 100) + "%";
        }
    }

    void DisplayStagePain()
    {
        try
        {
            Stage stage = StageManager.instance.currentStage;
            stagePainGauge.fillAmount = stage.PainGauge / stage.maxPain;
            stagePainText.text = "고통: " + Mathf.RoundToInt(stage.PainGauge / stage.maxPain * 100) + "%";
            if (stage.PainGauge / stage.maxPain >= 0.66f) highPainWarn.SetActive(true);
            else highPainWarn.SetActive(false);

        }

        catch
        {
            Stage stage = StageManager.instance.currentStage;
            stagePainGauge.fillAmount = stage.PainGauge / stage.maxPain;
            stagePainText.text = "고통: " + Mathf.RoundToInt(stage.PainGauge / stage.maxPain * 100) + "%";
        }
    }


    string scoreFormat;

    void DisplayScore()
    {
        scoreText.text = string.Format(scoreFormat, Mathf.RoundToInt(GameManager.instance.score)); 
    }


}
