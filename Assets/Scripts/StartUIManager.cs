using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartUIManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreStartUIText;

    void Start()
    {
        if(DataManager.Instance != null)
        {
            DataManager.Instance.LoadData();
            bestScoreStartUIText.SetText($"Best score: {DataManager.Instance.bestNickname} : {DataManager.Instance.bestOverallScore}");
        }
    }

}
