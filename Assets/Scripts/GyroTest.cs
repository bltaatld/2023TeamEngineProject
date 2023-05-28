using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour
{
    private Gyroscope gyro;
    private Quaternion initialRotation;

    void Start()
    {
        // 자이로 센서를 초기화합니다.
        gyro = Input.gyro;
        gyro.enabled = true;

        // 초기 회전값을 저장합니다.
        initialRotation = gyro.attitude;
    }

    void Update()
    {
        // 자이로 센서의 회전 값을 가져옵니다.
        Quaternion rotation = gyro.attitude;

        // 초기 회전값을 기준으로 상대적인 회전값을 계산합니다.
        Quaternion relativeRotation = Quaternion.Inverse(initialRotation) * rotation;

        // Z축 회전 각도를 추출합니다.
        float zAngle = relativeRotation.eulerAngles.z;

        // 오브젝트의 회전을 설정합니다.
        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);
    }

    // 회전값을 초기화하는 함수
    public void ResetRotation()
    {
        // 초기 회전값을 다시 설정합니다.
        initialRotation = gyro.attitude;
    }
}