using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class APInfo
{
    public float timer = 0f;
    public int currentHeart = 5;
    public DateTime exitTime = DateTime.Now;
}

public class SaveAPSystem : MonoBehaviour
{
    public APInfo apInfo;

    private string savePath;
    private string fileName;
    private string filePath;

    private StreamWriter sw;

    private void Awake()
    {
#if UNITY_ANDROID
        savePath = Application.persistentDataPath + "/Data/";
#endif
#if UNITY_EDITOR
        savePath = Application.dataPath + "/Data/";
#endif
        fileName = "APData.json";
        filePath = Path.Combine(savePath, "APData.json");
        LoadFromJson();
    }

    private void Start()
    {
        LoadFromJson();
    }

    public void SaveToJson()
    {
        string jsonData = JsonUtility.ToJson(apInfo);
        File.WriteAllText(filePath, jsonData);
    }

    public SaveAPSystem LoadFromJson()
    {
        if (!File.Exists(filePath))
        {
            apInfo = new APInfo();
            SaveToJson();
        }
        string jsonData = File.ReadAllText(filePath);
        if (string.IsNullOrEmpty(jsonData))
        {
            apInfo = new APInfo();
            SaveToJson();
            jsonData = File.ReadAllText(filePath);
        }
        apInfo = JsonUtility.FromJson<APInfo>(jsonData);

        return this;
    }
}
