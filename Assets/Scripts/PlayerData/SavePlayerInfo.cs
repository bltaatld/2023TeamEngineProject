using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class GameInfo
{
    public PlayerInfo playerInfo;
    public StageInfo[] stageInfo;
}


[System.Serializable]
public class StageInfo
{
    public string clearStage;
    public int rank;
}

[System.Serializable]
public class PlayerInfo
{
    public string playerName;
    public int playerGold;
}

public class SavePlayerInfo : MonoBehaviour
{
    public static SavePlayerInfo instance;
    public GameInfo gameInfo;
    public StageInfo[] stageInfos;
    public PlayerInfo playerInfo;

    private string savePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
#if UNITY_ANDROID
        savePath = Path.Combine(Application.persistentDataPath + "/Data/", "database.json");
#endif

#if UNITY_EDITOR
        savePath = Path.Combine(Application.dataPath + "/Data/", "database.json");
#endif
        Debug.Log(savePath);
        LoadPlayerInfoFromJson();
    }

    public void AddPlayerInfo(string stage, int rank, int gold)
    {
        // Check for duplicates
        for (int i = 0; i < stageInfos.Length; i++)
        {
            if (stageInfos[i].clearStage == stage)
            {
                // Duplicate found, update the existing entry
                stageInfos[i].rank = rank;
                SavePlayerInfoToJson();
                return;
            }
        }

        // No duplicate found, create a new PlayerInfo object and add it to the array
        StageInfo newPlayer = new StageInfo();
        newPlayer.clearStage = stage;
        newPlayer.rank = rank;

        playerInfo.playerGold += gold;

        Array.Resize(ref stageInfos, stageInfos.Length + 1);
        stageInfos[stageInfos.Length - 1] = newPlayer;

        SavePlayerInfoToJson();
    }

    public void SavePlayerInfoToJson()
    {
        gameInfo.stageInfo = new StageInfo[stageInfos.Length];

        for (int i = 0; i < stageInfos.Length; i++)
        {
            gameInfo.stageInfo[i] = stageInfos[i];
        }

        gameInfo.playerInfo = playerInfo;

        try
        {
            string json = JsonConvert.SerializeObject(gameInfo, Formatting.Indented);
            File.WriteAllText(savePath, json);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save player info to JSON: " + e.Message);
        }
    }

    public void LoadPlayerInfoFromJson()
    {
        if (File.Exists(savePath))
        {
            try
            {
                string json = File.ReadAllText(savePath);
                if (!string.IsNullOrEmpty(json))
                {
                    gameInfo = JsonConvert.DeserializeObject<GameInfo>(json);
                }
                else
                {
                    Debug.Log("Saved JSON file is empty.");
                    gameInfo = new GameInfo();
                }
            }
            catch (Exception e)
            {
                Debug.Log("Failed to load player info from JSON: " + e.Message);
                gameInfo = new GameInfo();
            }
        }
        else
        {
            Debug.Log("Saved JSON file does not exist.");
            gameInfo = new GameInfo();
        }
    }
}