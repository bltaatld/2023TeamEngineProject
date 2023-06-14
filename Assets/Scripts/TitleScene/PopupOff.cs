using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupOff : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject popup;
    public void OnPointerClick(PointerEventData eventData)
    {
        popup.SetActive(false);
    }
}
