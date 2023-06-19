using stageSelectScene;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelectBase : MonoBehaviour
{
    [SerializeField] protected GameObject selectLine;
    public Int32 expend = 200;
    public bool isSelected = false;
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = GameObject.Find("UIDirector").GetComponent<UIManager>();
    }

    private void Start()
    {
        InitPopup();
    }

    public void SelectItem()
    {
        if (isSelected)
        {
            isSelected = false;
        }
        else if(uiManager.CanUseCoin(expend))
        {
            isSelected = true;
        }

        selectLine.SetActive(isSelected);
    }

    public void InitPopup()
    {
        Debug.Log("Start Init");
        isSelected = false;
        selectLine.SetActive(isSelected);
    }
}
