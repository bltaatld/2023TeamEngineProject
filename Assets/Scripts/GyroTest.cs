using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    private Gyroscope gyro;

    void Start()
    {
        // ���̷� ������ �ʱ�ȭ�մϴ�.
        gyro = Input.gyro;
        gyro.enabled = true;
    }

    void Update()
    {
        // ���̷� ������ ȸ�� ���� �����ɴϴ�.
        Quaternion rotation = gyro.attitude;

        // Z�� ȸ�� ������ �����մϴ�.
        float zAngle = rotation.eulerAngles.z;

        // ������Ʈ�� ȸ���� �����մϴ�.
        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);
    }
}
