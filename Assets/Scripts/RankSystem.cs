using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RankData = SaveData.RankData;
using System.Linq;

public class RankSystem : MonoBehaviour
{

    public float finalScore;

    public GetNicknamePanel nicknamePanel;


    // Start is called before the first frame update
    void Start()
    {
        UpdateRankUI();

        finalScore = GameManager.instance.score;

        if(TryRankScore(finalScore))
        {
            GetNickName();
        }
    }

    public bool TryRankScore(float score)
    {
        int rank = 1; //1등이라고 가정
        foreach(RankData data in SaveData.instance.rankDatas)
        {
            if (data.Score > score) rank++;  
        }

        return rank <= 5;

    }

    public void SubmitRank()
    {

    }

    public void GetNickName()
    {
        nicknamePanel.gameObject.SetActive(true);
    }


    public void CreateRankData(TMP_InputField input)
    {
        nicknamePanel.gameObject.SetActive(false);
        RankData rankData = new RankData(input.text, finalScore);

        SaveData.instance.rankDatas.Add(rankData);
        SaveData.instance.rankDatas = SaveData.instance.rankDatas.OrderByDescending(x => x.Score).ThenBy(x => x.Name).ToList<RankData>();
        
        if(SaveData.instance.rankDatas.Count > 5)
        {
            SaveData.instance.rankDatas.RemoveRange(5, SaveData.instance.rankDatas.Count - 5);
        }

        UpdateRankUI();
    }

    public RankItem rankItem;
    public Transform contentParent;
    public void UpdateRankUI()

    {
        foreach(Transform item in contentParent)
        {
            Destroy(item.gameObject);
        }

        foreach(RankData data in SaveData.instance.rankDatas)
        {
            RankItem rankUI = Instantiate(rankItem, contentParent);
            rankUI.NameText.text = data.Name;
            rankUI.ScoreText.text = data.Score.ToString();
            rankUI.RankText.text = (SaveData.instance.rankDatas.IndexOf(data) + 1).ToString();
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
