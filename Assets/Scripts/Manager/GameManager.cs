using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string currentStage;
    public int currentRank;
    public int currentGold;
    public bool isStart;

    public PlayerMove playerMove;
    public CameraHandler cameraHandler;
    public TextMeshProUGUI timerText;

    public float gameTime;
    public float timeRemaining = 900f;
    public float rankValue;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddInfo()
    {
        SavePlayerInfo.instance.AddPlayerInfo(currentStage , currentRank, currentGold);
    }

    public void SaveInfo()
    {
        SavePlayerInfo.instance.SavePlayerInfoToJson();
    }

    private void Update()
    {
        
        if (rankValue >= 50)
        {
            currentRank = 1;
        }

        if (rankValue >= 100)
        {
            currentRank = 2;
        }

        if (rankValue >= 200)
        {
            currentRank = 3;
        }

        if (timeRemaining > 0 && isStart)
        {
            timeRemaining -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60f);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }

        if(timeRemaining < 0 && isStart)
        {
            AddInfo();
            SaveInfo();
            Loader.LoadScene("GameClearScene");
        }
    }
}
