using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using stageSelectScene;

public class StageReadyPopup : MonoBehaviour
{
    [HideInInspector] public string tempStage;
    [SerializeField] private TextMeshProUGUI[] texts = new TextMeshProUGUI[2];
    [SerializeField] private GameObject startPopup;
    [SerializeField] private ItemSelectBase[] itemButtons = new ItemSelectBase[2];

    public void SetPopup(string stageNum)
    {
        tempStage = stageNum;

        texts[0].text = $"STAGE {tempStage}";
        //texts[1].text = script in Dictionary with index-tempStage;
        if (GameObject.Find("TestObj").GetComponent<StoryCSVReader>().storyDatas.ContainsKey(stageNum))
        {
            texts[1].text = GameObject.Find("TestObj").GetComponent<StoryCSVReader>().storyDatas[stageNum][0];
        }
        else
        {
            Debug.LogError("Can't Load Story");
        }
    }

    public void ReadyStage()
    {
        startPopup.SetActive(true);
        foreach(var item in itemButtons)
        {
            item.InitPopup();
        }
        startPopup.GetComponent<StageStartButton>().SetPopup(tempStage);
    }
}
