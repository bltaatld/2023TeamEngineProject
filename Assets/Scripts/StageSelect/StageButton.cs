using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class StageButton : MonoBehaviour
{
    [SerializeField] private int stageNum = -1;
    [SerializeField] private bool isUnlocked = false;
    [SerializeField] private Sprite[] buttonSprites = new Sprite[3];

    private TextMeshProUGUI m_stageNum;
    private GameObject m_seaweedParent;
    private GameObject m_Popup;

    private void Awake()
    {
        if(stageNum == -1)
        {
            stageNum = this.transform.GetSiblingIndex() + 1;
        }

        m_stageNum = this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        m_stageNum.text = stageNum.ToString();

        m_seaweedParent = this.transform.GetChild(1).gameObject;

        m_Popup = GameObject.FindObjectOfType<StageStartPopup>(true).gameObject;

        if(stageNum == 1)
        {
            isUnlocked = true;
        }
    }

    private void Start()
    {
        UpdateButton();
    }

    public void UpdateButton()
    {
        //데이터를 확인해 상호작용가능 유무, 클리어 유무로 다른 스프라이트 적용
        Button thisButton = this.GetComponent<Button>();
        Image thisImage = this.GetComponent<Image>();

        //if(stage is locked)
        //button.interactable = false;
        //image = images[0];
        //return;
        if (!isUnlocked)
        {
            thisButton.interactable = false;
            thisImage.sprite = buttonSprites[0];
            m_seaweedParent.SetActive(false);
            return;
        }

        //if(button.interatable == false)
        //button.interactable = true;
        if (!thisButton.interactable)
        {
            thisButton.interactable = true;
        }

        //if(stage has been cleared)
        //  if(next stage is locked) nextStage.isUnlocked = true; nextStage.UpdateButton();
        //image = images[1];
        //m_seaweedParent.UpdateRecord();
        //return;
        if(true/*수정 필요*/)
        {
            if (this.stageNum < this.transform.parent.childCount && !this.transform.parent.GetChild(stageNum).GetComponent<StageButton>().isUnlocked)
            {
                StageButton nextStage = this.transform.parent.GetChild(stageNum).GetComponent<StageButton>();
                nextStage.isUnlocked = true;
                nextStage.UpdateButton();
            }
            thisImage.sprite = buttonSprites[1];
            m_seaweedParent.SetActive(true);
            m_seaweedParent.GetComponent<SeaweedRecordSystem>().SetRecord();
            return;
        }

        //image = images[2];
        //return;
        thisImage.sprite = buttonSprites[2];
        m_seaweedParent.SetActive(false);
        return;
    }

    //Button-OnClick Method
    public void OpenPopup()
    {
        m_Popup.SetActive(true);
        m_Popup.GetComponent<StageStartPopup>().SetPopup(stageNum);
    }
}
