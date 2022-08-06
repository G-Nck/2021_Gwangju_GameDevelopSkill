using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        AtkLevelUp,
        God,
        PlayerHeal,
        StageHeal,
        AtkSpeedUp,
        AtkDamageBuff,
        Bomb,
        Ultimate
    }

    public ItemType type;

    public UnityEvent<Player> OnPicked;



    // Start is called before the first frame update
    void Start()
    {
        OnPicked.AddListener((_) => GetScore());
    }

    public float scoreAmount;
    public void GetScore()
    {
        GameManager.instance.score += scoreAmount;
    }


    public UnityAction<Player> GetItemAction()
    {
        switch (type)
        {
            case ItemType.AtkLevelUp:
                return PlayerAttackLevelUp;
            case ItemType.God:
                return PlayerGod;
            case ItemType.PlayerHeal:
                return HealPlayer;
            case ItemType.StageHeal:
                return HealStage;
            case ItemType.AtkSpeedUp:
                return PlayerAttackSpeedUp;
            case ItemType.AtkDamageBuff:
                return PlayerAttackDamageBuff;
            case ItemType.Bomb:
                return GetBomb;
            case ItemType.Ultimate:
                return GetUltimate;
 
        }
        return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OnPicked?.Invoke(collision.GetComponent<Player>());
            GetItemAction().Invoke(collision.GetComponent<Player>());
            Destroy(gameObject);
        }
    }


    public void PlayerAttackLevelUp(Player player)
    {
        player.GetComponent<PlayerAttackModule>().AttackLevelUp();
    }

    public void PlayerGod(Player player)
    {
        player.OnPlayerGetGodItem();
    }

    public void HealPlayer(Player player)
    {
        player.GetComponent<LivingEntity>().CurrentHP += 35;
    }
    public void HealStage(Player player)
    {
        StageManager.instance.currentStage.PainGauge -= 35;
    }
    public void PlayerAttackSpeedUp(Player player)
    {
        PlayerAttackModule module = player.GetComponent<PlayerAttackModule>();
        module.atkSpeed = Mathf.Min(module.atkSpeed + 0.25f, 2);
    }
    public void PlayerAttackDamageBuff(Player player)
    {
        PlayerAttackModule module = player.GetComponent<PlayerAttackModule>();
        module.buffTimer = 10;
    }
    public void GetBomb(Player player)
    {
        player.BombCount++;
    }
    public void GetUltimate(Player player)
    {
        player.UltimateCount++;
    }

}
