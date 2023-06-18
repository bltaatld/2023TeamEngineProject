using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupOff : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _popup;
    [SerializeField] private int _popupIndex = 0;
    [SerializeField] private string _closeAnimName;
    private Animator animator;

    private void Awake()
    {
        animator = _popup.GetComponent<Animator>();
        animator.SetBool("isClose", false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;
        GameObject popup = this.transform.GetChild(_popupIndex).gameObject;
        //Debug.Log(popup.name);
        Vector3 popupPos = popup.GetComponent<RectTransform>().anchoredPosition;
        Vector2 popupSize = popup.GetComponent<RectTransform>().sizeDelta;
        Vector3 mousePos = /*Camera.main.ScreenToWorldPoint*/(new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0));

        //Debug.Log($"Popup Off Clicked From : {transform.name}"); 
        if(!(mousePos.x >= popupPos.x - popupSize.x / 2 && mousePos.x <= popupPos.x + popupSize.x / 2
            && mousePos.y >= popupPos.y - popupSize.y / 2 && mousePos.y <= popupPos.y + popupSize.y / 2)
            && clickCount == 1)
        {
            //Debug.Log($"Popup Success From: {transform.name}");
            StartCoroutine(StartCloseAnim());
        }
        else
        {
            Debug.Log($"Popup Failed From: {transform.name}");
            //Debug.Log(popupPos);
            //Debug.Log(mousePos);
            //Debug.Log($"mousePos.x >= popupPos.x - popupSize.x / 2 : {mousePos.x >= popupPos.x - popupSize.x / 2}");
            //Debug.Log($"mousePos.x <= popupPos.x + popupSize.x / 2 : {mousePos.x <= popupPos.x + popupSize.x / 2}");
            //Debug.Log($"mousePos.y >= popupPos.y - popupSize.y / 2 : {mousePos.y >= popupPos.y - popupSize.y / 2}");
            //Debug.Log($"mousePos.y <= popupPos.y + popupSize.y / 2 : {mousePos.y <= popupPos.y + popupSize.y / 2}");
            //Debug.Log($"clickCount = {clickCount}");
        }
    }

    public void ClickXButton()
    {
        StartCoroutine(StartCloseAnim());
    }

    private IEnumerator StartCloseAnim()
    {
        animator.SetBool("isClose", true);
        while (true)
        {
            yield return null;
            if(animator.GetCurrentAnimatorStateInfo(0).IsName(_closeAnimName))
            {
                break;
            }
        }
        _popup.SetActive(false);
        yield break;
    }
}
