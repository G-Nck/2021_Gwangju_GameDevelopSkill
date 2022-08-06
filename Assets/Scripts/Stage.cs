using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stage : MonoBehaviour
{
    public bool isLastStage = false;

    public float maxPain;
    private float painGauge;

    public float PainGauge
    {
        get { return painGauge; }
        set {
            painGauge = Mathf.Clamp(value, 0, maxPain);

            if (painGauge >= maxPain) GameManager.instance.GameOver();
        }
    }

    public float startPainPercent;


    public List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> activeEnemies = new List<Enemy>();
    public List<Boss> bosses = new List<Boss>();
    public List<Boss> activeBosses = new List<Boss>();


    public UnityEvent OnStageStart;
    public UnityEvent OnStageClear;



    private void OnEnable()
    {
        OnStageStart?.Invoke();
        painGauge = maxPain / 100 * startPainPercent;

        activeEnemies.Clear();

        foreach(Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
            activeEnemies.Add(enemy);
        }
        foreach(Boss boss in bosses)
        {
            boss.gameObject.SetActive(true);

        }

        
        bosses[0].gameObject.SetActive(false);

    }


    public void OnEnemyDisabled(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
        if(activeEnemies.Count == 0)
        {
            bosses[0].Appear();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach(Enemy enemy in enemies)
        {
            enemy.OnEnemyDisabled.AddListener(() => OnEnemyDisabled(enemy));
        }
    }




    public void GiveScore()
    {
        GameManager.instance.score += Mathf.RoundToInt(maxPain - painGauge);
    }


    public void ClearStage()
    {
        OnStageClear?.Invoke();
    }
}
