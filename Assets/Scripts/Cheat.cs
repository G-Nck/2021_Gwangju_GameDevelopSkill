using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Cheat : MonoBehaviour
{


    public Slider painCheat;
    public Slider hpCheat;

    public Spawner[] redCellSpawner;
    public Spawner whiteCellSpawner;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            //Stage 1���� �̵�
            StageManager.instance.CheatLoadStage(0);

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            //Stage 2���� �̵�
            StageManager.instance.CheatLoadStage(1);

        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            //�÷��̾� ���� ��ȭ
            GameManager.instance.player.GetComponent<PlayerAttackModule>().AttackLevelUp();
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            //�÷��̾� �������·�
            GameManager.instance.player.godEffectTimer = Mathf.Infinity;
            GameManager.instance.player.godTimer = Mathf.Infinity;
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            //�÷��̾� �������� ����
            GameManager.instance.player.godEffectTimer = 0;
            GameManager.instance.player.godTimer = 0;
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            //������ ��� ���� ��ġ (��������)
            Enemy[] enemies = FindObjectsOfType<Enemy>();
            foreach(Enemy enemy in enemies)
            {
                if (enemy.team != Character.Team.Enemy) continue;
                if(!enemy.gameObject.activeSelf) continue;
                Vector3 viewpos = Camera.main.WorldToViewportPoint(enemy.transform.position);
                if (viewpos.y > -0.1f && viewpos.y < 1.1f)
                {
                    
                    enemy.DisableCharacter();
                    enemy.gameObject.SetActive(false);
                }
            }
            
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            //ü�� ������ ����

            hpCheat.gameObject.SetActive(!hpCheat.gameObject.activeSelf);

        }
        if (Input.GetKeyDown(KeyCode.F8))
        {
            //���� ������ ����
            painCheat.gameObject.SetActive(!painCheat.gameObject.activeSelf);


        }

        if(Input.GetKeyDown(KeyCode.F9))
        {
            redCellSpawner[Random.Range(0, redCellSpawner.Length)].Spawn();
        }

        if (Input.GetKeyDown(KeyCode.F10))
        {
            whiteCellSpawner.Spawn();
        }


    }


    public Single PlayerHP
    {
        

        set
        {
            LivingEntity entity = GameManager.instance.player.GetComponent<LivingEntity>();
            entity.CurrentHP = entity.MaxHP * value;
        }
    }
    public Single StagePain
    {

        set
        {
            Stage stage = StageManager.instance.currentStage;
            stage.PainGauge = stage.maxPain * value;
        }
    }


    public void SetPlayerHP()
    {

    }



   
}
