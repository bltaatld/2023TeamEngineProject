using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
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

    private void Awake()
    {
#if UNITY_EDITOR
        savePath = Application.persistentDataPath + "/Data/";
#endif
        //#if UNITY_ANDROID
        //        savePath = Application.dataPath + "/Data/";
        //#endif
#if UNITY_ANDROID
        savePath = Application.persistentDataPath + "/Data/";
#endif
        fileName = "APData.json";
        filePath = Path.Combine(savePath, fileName);
        LoadFromJson();
    }

    private void Start()
    {
        LoadFromJson();
    }

    public void SaveToJson()
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        try
        {
            string ap = JsonUtility.ToJson(apInfo);
            File.WriteAllText(filePath, ap);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed To Save AP Data by {e}");
        }
    }

    public void LoadFromJson()
    {
        if (File.Exists(filePath))
        {
            try
            {
                string json = File.ReadAllText(filePath);
                if (!string.IsNullOrEmpty(json))
                {
                    apInfo = JsonConvert.DeserializeObject<APInfo>(json);
                }
                else
                {
                    Debug.LogError("AP json is empty");
                    apInfo = new APInfo();
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Fail Load AP Data Json by {e}");
                apInfo = new APInfo();
            }
        }
        else
        {
            //Debug.LogError("AP Data Json isn't exist");
            apInfo = new APInfo();
            SaveToJson();
        }
    }
}
