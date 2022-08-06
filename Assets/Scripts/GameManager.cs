using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;



    public float score;

    public Player player;

    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += ResetScore;


    }


    public void ResetScore(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GameScene")
            score = 0;
    }



    public void GameOver()
    {
        SceneManager.LoadScene("ResultScene");
    }

}
