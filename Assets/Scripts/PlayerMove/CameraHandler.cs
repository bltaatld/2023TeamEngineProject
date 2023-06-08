using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform 컴포넌트
    public Transform childTransform;
    private Vector3 childeOffset; // 카메라와 플레이어 사이의 거리


    public void CenterCameraOnPlayerPosition()
    {
        childeOffset = childTransform.position;
        Vector3 targetPosition = playerTransform.position;
        Camera.main.transform.position = new Vector3(targetPosition.x, targetPosition.y, Camera.main.transform.position.z);
        childTransform.position = childeOffset;
    }
}
