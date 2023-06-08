using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string currentStage;
    public int currentRank;
    public int currentGold;

    public PlayerMove playerMove;
    public CameraHandler cameraHandler;

    public void Awake()
    {
        instance = this;
    }

    public void AddInfo()
    {
        SavePlayerInfo.instance.AddPlayerInfo(currentStage, currentRank, currentGold);
    }

    public void SaveInfo()
    {
        SavePlayerInfo.instance.SavePlayerInfoToJson();
    }
}
