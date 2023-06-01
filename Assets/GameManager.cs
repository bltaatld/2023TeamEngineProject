using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMove playerMove;

    public void Awake()
    {
        instance = this;
    }
}
