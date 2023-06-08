using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
	public Transform weed;
	public float speed;
	public float distanceFromWall = 0.1f;
	public LayerMask wallLayer;
	public float moveDuration = 3f;
	public float moveTimer = 0f;
	public SpriteRenderer curserRender;

	public bool isMoving = false;
	public bool CanMove;
	private bool isButtonPressed = false;
	private Vector2 targetPosition;
	private Vector2 startPosition;

	void Update()
	{
		transform.Rotate(Vector3.back * speed * Time.deltaTime);
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			// ù ��° ��ġ �Է��� Ȯ���ϰ�, UI ��ư�� Ŭ������ �ʾ��� �� �Լ��� �۵��մϴ�.
			if (touch.phase == TouchPhase.Began && !isButtonPressed && !isMoving && !CanMove && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
			{
                Camera.main.orthographicSize = 40f;
                isMoving = true;
                moveTimer = 0f;
                startPosition = transform.position;

                // �÷��̾� ȸ�� ��
                float playerAngle = transform.eulerAngles.z;

                // ������ ��������
                float angleInRadians = playerAngle * Mathf.Deg2Rad;

                // �÷��̾��� ȸ���� �����Ͽ� Raycast ������ �����մϴ�.
                Vector2 playerDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

                // Raycast�� �����Ͽ� ������ �浹�� �����մϴ�.
                RaycastHit2D hit = Physics2D.Raycast(transform.position, playerDirection, Mathf.Infinity, wallLayer);

                // Raycast�� ���� �¾��� ���� ó���� �����մϴ�.
                if (hit.collider != null)
                {
                    Vector2 hitPoint = hit.point;
                    targetPosition = hitPoint - playerDirection * distanceFromWall;
                }

                Quaternion currentRotation = transform.rotation;

                // ���� rotation�� z ���� 180�� ȸ���մϴ�.
                currentRotation *= Quaternion.Euler(0f, 0f, 180f);

                // ����� rotation ���� �����մϴ�.
                transform.rotation = currentRotation;
            }
		}

		if (isMoving)
		{
			moveTimer += Time.deltaTime;

			if (moveTimer <= moveDuration)
			{
				float t = moveTimer / moveDuration;
				transform.position = Vector2.Lerp(startPosition, targetPosition, t);
				curserRender.gameObject.SetActive(false);
			}
			else
			{
				isMoving = false;
				curserRender.gameObject.SetActive(true);
				GameManager.instance.cameraHandler.CenterCameraOnPlayerPosition();
            }
		}
	}

    /*public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			Debug.Log("Hit");
			speed *= -1f;
		}
	}*/

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ground"))
		{
			Debug.Log("Hit");
			speed *= -1f;
		}
	}
}
