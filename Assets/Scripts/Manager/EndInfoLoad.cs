using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndInfoLoad : MonoBehaviour
{
    public TextMeshProUGUI stageName;
    public TextMeshProUGUI goldText;
    public GameObject Rank1;
    public GameObject Rank2;
    public GameObject Rank3;

    void Start()
    {
        stageName.text = "Stage " + GameManager.instance.currentStage;
        goldText.text = GameManager.instance.currentGold.ToString();

        if (GameManager.instance.rankValue >= 50)
        {
            Rank1.SetActive(true);
        }

        if (GameManager.instance.rankValue >= 100)
        {
            Rank1.SetActive(true);
            Rank2.SetActive(true);
        }

        if (GameManager.instance.rankValue >= 200)
        {
            Rank1.SetActive(true);
            Rank2.SetActive(true);
            Rank3.SetActive(true);
        }
    }
}
