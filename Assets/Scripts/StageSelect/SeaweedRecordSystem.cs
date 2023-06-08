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

    public void SetRecord()
    {
        //stageRecord저장 방법 회의 필요?
        Debug.Log("미역(별)시스템정비중입니다...");
    }
}
