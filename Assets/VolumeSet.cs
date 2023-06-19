using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSet : MonoBehaviour
{
    public GameObject BackgroundMusic;

    private void Start()
    {
        BackgroundMusic = GameObject.Find("BGM");
    }

    public void SetVolume(float value)
    {
        BackgroundMusic.GetComponent<AudioSource>().volume = value;
    }
}
