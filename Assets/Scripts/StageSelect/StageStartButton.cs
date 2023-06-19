using stageSelectScene;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageStartButton : MonoBehaviour
{
    [HideInInspector] public string tempStage;
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private ItemSelectBase[] itemButtons = new ItemSelectBase[2];
    public void SetPopup(string stageNum)
    {
        foreach(var item in itemButtons)
        {
            item.InitPopup();
        }

        tempStage = stageNum;

        stageText.text = $"STAGE {tempStage}";
    }
    public void StartStage()
    {
        GameObject uiManager = GameObject.Find("UIDirector");
        foreach(var item in itemButtons)
        {
            if (item.isSelected)
            {
                uiManager.GetComponent<UIManager>().ReduceCoin(item.expend);
                PlayerPrefs.SetInt(item.gameObject.transform.parent.name, 1);
            }
            else
            {
                PlayerPrefs.SetInt(item.gameObject.transform.parent.name, 0);
            }
        }
        uiManager.GetComponent<SaveAPSystem>().apInfo.currentHeart--;
        uiManager.GetComponent<UIManager>().SetExitMode();
        SceneManager.LoadScene(tempStage);
    }
}
