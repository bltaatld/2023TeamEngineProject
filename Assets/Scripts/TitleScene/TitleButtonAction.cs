using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonAction : MonoBehaviour
{
    [SerializeField] private GameObject nameSelect;
    [SerializeField] private GameObject optionPopup;
    public void startGame()
    {
        if(SavePlayerInfo.instance.playerInfo.playerName == "" || SavePlayerInfo.instance.playerInfo.playerName == null)
        {
            nameSelect.SetActive(true);
            return;
        }
        SceneManager.LoadScene("StageSelectScene");
    }

    public void OpenOption()
    {
        optionPopup.SetActive(true);
        return;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
