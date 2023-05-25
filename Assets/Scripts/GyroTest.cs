using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    private Gyroscope gyro;

    void Start()
    {
        // 자이로 센서를 초기화합니다.
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        // 자이로 센서의 회전 값을 가져옵니다.
        Quaternion rotation = gyro.attitude;

        // Z축 회전 각도를 추출합니다.
        float zAngle = rotation.eulerAngles.z;

        // 오브젝트의 회전을 설정합니다.
        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);
    }
}
