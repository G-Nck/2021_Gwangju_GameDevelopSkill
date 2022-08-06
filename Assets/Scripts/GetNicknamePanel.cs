using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetNicknamePanel : MonoBehaviour
{
    public TMP_InputField nicknameInput;

    public CanvasGroup warnPanel;
    public RankSystem rankSystem;

    public void TrySubmitRank()
    {
        if(string.IsNullOrEmpty(nicknameInput.text) || string.IsNullOrWhiteSpace(nicknameInput.text))
        {
            warnPanel.alpha = 1;
        }

        else
        {
            SubmitRank();
        }
    }


    public void SubmitRank()
    {
        rankSystem.CreateRankData(nicknameInput);
    }

    private void Update()
    {
        warnPanel.alpha -= Time.deltaTime;
    }




}
