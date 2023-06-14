using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void MoveScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
