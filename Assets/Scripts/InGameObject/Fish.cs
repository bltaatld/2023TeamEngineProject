using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float heal;
    public float maxLife;
    public float currentLife;
    public bool isInWater;

    private void Start()
    {
        currentLife = maxLife;
    }

    private void Update()
    {
        if(currentLife < 0)
        {
            Destroy(gameObject);
        }

        if (!isInWater)
        {
            currentLife -= Time.deltaTime;
        }

        if (isInWater)
        {
            currentLife = maxLife;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.playerMove.weedGage += heal;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Liqid"))
        {
            isInWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Liqid"))
        {
            isInWater = false;
        }
    }
}
