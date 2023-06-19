using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SameToTarget : MonoBehaviour
{
    [SerializeField]
    Image progressBar;

    [SerializeField]
    Image barSelf;

    void Update()
    {
        barSelf.fillAmount = progressBar.fillAmount;
    }
}
