using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // 플레이어 오브젝트의 Transform 컴포넌트
    public Image uiImage; // 따라다닐 UI Image 컴포넌트

    private void LateUpdate()
    {
        transform.position = playerTransform.position;
        transform.rotation = playerTransform.rotation;
        uiImage.fillAmount = GameManager.instance.playerMove.weedGage / 100f;
    }
}
