using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform weed;
    public float speed;
    public float distanceFromWall = 0.1f;
    public LayerMask wallLayer;
    public float moveDuration = 3f;
    public float moveTimer = 0f;

    private bool isMoving = false;
    private Vector2 targetPosition;
    private Vector2 startPosition;

    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            moveTimer = 0f;
            startPosition = transform.position;

            // 플레이어 회전 값
            float playerAngle = transform.eulerAngles.z;

            // 각도를 라디안으로
            float angleInRadians = playerAngle * Mathf.Deg2Rad;

            // 플레이어의 회전을 적용하여 Raycast 방향을 설정합니다.
            Vector2 playerDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

            // Raycast를 수행하여 벽과의 충돌을 감지합니다.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, Mathf.Infinity, wallLayer);

            // Raycast가 벽에 맞았을 때의 처리를 수행합니다.
            if (hit.collider != null)
            {
                Vector2 hitPoint = hit.point;
                targetPosition = hitPoint - playerDirection * distanceFromWall;
            }

            Quaternion currentRotation = transform.rotation;

            // 현재 rotation의 z 값을 180도 회전합니다.
            currentRotation *= Quaternion.Euler(0f, 0f, 180f);

            // 변경된 rotation 값을 적용합니다.
            transform.rotation = currentRotation;
        }

        if (isMoving)
        {
            moveTimer += Time.deltaTime;

            if (moveTimer <= moveDuration)
            {
                float t = moveTimer / moveDuration;
                transform.position = Vector2.Lerp(startPosition, targetPosition, t);
            }
            else
            {
                isMoving = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("Hit");
            speed *= -1f;
        }
    }
}
