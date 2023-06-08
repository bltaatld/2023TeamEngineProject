using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool isStartActive;
    public string startChangeName;

    public void Start()
    {
        if(isStartActive)
        {
            Change(startChangeName);
        }
    }

    public void Change(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
