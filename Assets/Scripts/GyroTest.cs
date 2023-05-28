using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour
{
    private Gyroscope gyro;
    private Quaternion initialRotation;

    void Start()
    {
        // ���̷� ������ �ʱ�ȭ�մϴ�.
        gyro = Input.gyro;
        gyro.enabled = true;

        // �ʱ� ȸ������ �����մϴ�.
        initialRotation = gyro.attitude;
    }

    void Update()
    {
        // ���̷� ������ ȸ�� ���� �����ɴϴ�.
        Quaternion rotation = gyro.attitude;

        // �ʱ� ȸ������ �������� ������� ȸ������ ����մϴ�.
        Quaternion relativeRotation = Quaternion.Inverse(initialRotation) * rotation;

        // Z�� ȸ�� ������ �����մϴ�.
        float zAngle = relativeRotation.eulerAngles.z;

        // ������Ʈ�� ȸ���� �����մϴ�.
        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);
    }

    // ȸ������ �ʱ�ȭ�ϴ� �Լ�
    public void ResetRotation()
    {
        // �ʱ� ȸ������ �ٽ� �����մϴ�.
        initialRotation = gyro.attitude;
    }
}