using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darimi : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.playerMove.weedGage -= damage;
            Destroy(gameObject);
        }
    }
}
