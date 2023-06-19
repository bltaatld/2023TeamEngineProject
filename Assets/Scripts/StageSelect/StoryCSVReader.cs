using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class StoryCSVReader : MonoBehaviour
{
    public Dictionary<string, string[]> storyDatas = new Dictionary<string, string[]>();
    private string dataPath;
    private string filePath, fileName;

    private void Awake()
    {
#if UNITY_EDITOR
        filePath = Application.persistentDataPath + "/Data/";
#endif
#if UNITY_ANDROID
        filePath = Application.dataPath + "/Data/";
#endif
        fileName = "StoryScripts.csv";

        dataPath = Path.Combine(filePath, fileName);

        ReadData();
    }

    void ReadData()
    {
        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        StreamReader file = new StreamReader(dataPath);

        while (!file.EndOfStream)
        {
            string line = file.ReadLine();
            string[] fields = CSVParser.Split(line);
            for(int j = 0; j < fields.Length; j++)
            {
                fields[j] = fields[j].TrimStart(' ', '"');
                fields[j] = fields[j].TrimEnd('"');
            }
            if (!storyDatas.TryAdd(fields[0], new string[] { fields[1], fields[2] }))
            {
                Debug.LogError("Fail to Parse Stroy");
            }
        }
    }
}
