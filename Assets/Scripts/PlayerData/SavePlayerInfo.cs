using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

[System.Serializable]
public class PlayerInfo
{
    public string clearStage;
    public int rank;
    public int gold;
}

public class SavePlayerInfo : MonoBehaviour
{
    public static SavePlayerInfo instance;
    public PlayerInfo[] playerInfo;

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

        savePath = Path.Combine(Application.dataPath + "/Data/", "database.json");
        LoadPlayerInfoFromJson();
    }

    public void AddPlayerInfo(string stage, int rank, int gold)
    {
        // Check for duplicates
        for (int i = 0; i < playerInfo.Length; i++)
        {
            if (playerInfo[i].clearStage == stage)
            {
                // Duplicate found, update the existing entry
                playerInfo[i].rank = rank;
                playerInfo[i].gold = gold;
                SavePlayerInfoToJson();
                return;
            }
        }

        // No duplicate found, create a new PlayerInfo object and add it to the array
        PlayerInfo newPlayer = new PlayerInfo();
        newPlayer.clearStage = stage;
        newPlayer.rank = rank;
        newPlayer.gold = gold;

        Array.Resize(ref playerInfo, playerInfo.Length + 1);
        playerInfo[playerInfo.Length - 1] = newPlayer;

        SavePlayerInfoToJson();
    }

    public void SavePlayerInfoToJson()
    {
        try
        {
            string json = JsonConvert.SerializeObject(playerInfo, Formatting.Indented);
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
                    playerInfo = JsonConvert.DeserializeObject<PlayerInfo[]>(json);
                }
                else
                {
                    Debug.LogWarning("Saved JSON file is empty.");
                    playerInfo = new PlayerInfo[0];
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load player info from JSON: " + e.Message);
                playerInfo = new PlayerInfo[0];
            }
        }
        else
        {
            Debug.LogWarning("Saved JSON file does not exist.");
            playerInfo = new PlayerInfo[0];
        }
    }
}