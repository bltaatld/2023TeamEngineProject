using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaweedRecordSystem : MonoBehaviour
{
    [SerializeField] private Sprite[] cleareds = new Sprite[3];
    [SerializeField] private Sprite[] uncleareds = new Sprite[3];

    private GameObject[] seaweeds = new GameObject[3];

    private void Awake()
    {
        for(int i = 0; i < seaweeds.Length; i++)
        {
            seaweeds[i] = this.transform.GetChild(i).gameObject;
        }
    }

    public void SetRecord(string stageName, int index)
    {
        if(index == -1)
        {
            Debug.LogError("Record Error");
            return;
        }

        int record = SavePlayerInfo.instance.stageInfos[index].rank;

        if(record == 1)
        {
            seaweeds[0].GetComponent<Image>().sprite = cleareds[0];
            seaweeds[1].GetComponent<Image>().sprite = uncleareds[1];
            seaweeds[2].GetComponent<Image>().sprite = uncleareds[2];
        }
        else if (record == 2)
        {
            seaweeds[0].GetComponent<Image>().sprite = cleareds[0];
            seaweeds[1].GetComponent<Image>().sprite = cleareds[1];
            seaweeds[2].GetComponent<Image>().sprite = uncleareds[2];
        }
        else if (record == 3)
        {
            seaweeds[0].GetComponent<Image>().sprite = cleareds[0];
            seaweeds[1].GetComponent<Image>().sprite = cleareds[1];
            seaweeds[2].GetComponent<Image>().sprite = cleareds[2];
        }
        else
        {
            Debug.LogError($"Record Info Error : index == {index}");
            return;
        }
    }
}
