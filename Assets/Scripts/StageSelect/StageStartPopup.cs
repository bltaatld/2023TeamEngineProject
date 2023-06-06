using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageStartPopup : MonoBehaviour
{
    [HideInInspector] public int tempStage;
    [SerializeField] private TextMeshProUGUI[] texts = new TextMeshProUGUI[2];

    public void SetPopup(int stageNum)
    {
        tempStage = stageNum;

        texts[0].text = $"STAGE {tempStage}";
        //texts[1].text = script in Dictionary with index-tempStage;
    }
}
