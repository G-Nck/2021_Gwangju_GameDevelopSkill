using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;


    [Serializable]
    public struct RankData
    {
        public string Name;
        public float Score;

        public RankData(string name, float score)
        {
            this.Name = name;
            Score = score;
        }
    }
        
    public List<RankData> rankDatas = new List<RankData>();


    private void Awake()
    {
        if(SaveData.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
