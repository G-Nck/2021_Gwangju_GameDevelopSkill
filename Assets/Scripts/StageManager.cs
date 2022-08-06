using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public static StageManager instance;

    public List<Stage> stages = new List<Stage> ();

    public Stage prevStage;
    public Stage PrevStage
    {
        get { return prevStage; }
        set { prevStage = value;
        prevStage.gameObject.SetActive (false);}
    }

    public Stage currentStage;

    public Stage CurrentStage
    {
        get { return currentStage; }
        set { currentStage = value;
        currentStage.gameObject.SetActive (true); }
    }


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        CurrentStage = stages[0];
    }




    public void NextStage()
    {
        if (!CurrentStage.isLastStage)
            UIManager.instance.animator.SetInteger("StageIndex", stages.IndexOf(CurrentStage) + 1);
        else UIManager.instance.animator.SetTrigger("GameClear");

    }
    public void LoadStage(int index)
    {
        PrevStage = currentStage;
        CurrentStage = stages[index];

        ClearStage();
    }
    public void ClearStage()
    {
        Projectile[] bullets = FindObjectsOfType<Projectile>();
        foreach (Projectile bullet in bullets)
        {
            Destroy(bullet.gameObject);

        }
        WhiteCell[] whiteCells = FindObjectsOfType<WhiteCell>();
        foreach (WhiteCell cell in whiteCells)
        {
            Destroy(cell.gameObject);

        }
        RedCell[] redCells = FindObjectsOfType<RedCell>();
        foreach (RedCell redCell in redCells)
        {
            Destroy(redCell.gameObject);

        }
        Item[] items = FindObjectsOfType<Item>();
        foreach (Item item in items)
        {
            Destroy(item.gameObject);

        }
    }

    public void CheatLoadStage(int index)
    {
        UIManager.instance.animator.SetInteger("StageIndex", index);
    }

}
