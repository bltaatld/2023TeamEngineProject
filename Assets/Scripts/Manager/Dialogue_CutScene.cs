using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_CutScene : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject textObject;

    public string[] lines;
    public float textSpeed;
    public float clickSpeed;
    public bool Check;

    public float currentDelayTime = 0.0f;
    public float elapsedTime = 0.0f;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        startDialogue();
        textComponent.text = string.Empty;
        GameManager.instance.isStart = false;
        Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                elapsedTime = 0.0f;
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(WaitClickTime(clickSpeed));
                textComponent.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void SetCheckFalse(bool setbool)
    {
        Check = setbool;
    }

    IEnumerator WaitClickTime(float i)
    {
        yield return new WaitForSeconds(i);
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 0;
            Check = true;
            Debug.Log("Text Ended");
            textObject.SetActive(false);
            GameManager.instance.isStart = true;
        }
    }
}
