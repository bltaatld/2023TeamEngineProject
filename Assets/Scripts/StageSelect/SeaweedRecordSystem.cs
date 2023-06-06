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
        //stageRecord���� ��� ȸ�� �ʿ�?
        Debug.Log("�̿�(��)�ý����������Դϴ�...");
    }
}
