using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using stageSelectScene;

public class StageStartPopup : MonoBehaviour
{
    [HideInInspector] public string tempStage;
    [SerializeField] private TextMeshProUGUI[] texts = new TextMeshProUGUI[2];

    public void SetPopup(string stageNum)
    {
        tempStage = stageNum;

        texts[0].text = $"STAGE {tempStage}";
        //texts[1].text = script in Dictionary with index-tempStage;
    }

    public void StartStage()
    {
        GameObject uiManager = GameObject.Find("UIDirector");
        uiManager.GetComponent<SaveAPSystem>().apInfo.currentHeart--;
        uiManager.GetComponent<UIManager>().SetExitMode();
        SceneManager.LoadScene(tempStage);
    }
}
