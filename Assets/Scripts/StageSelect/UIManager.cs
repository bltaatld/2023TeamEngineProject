using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace stageSelectScene{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_coin;
        [SerializeField] private TextMeshProUGUI m_heart;

        private float standardTime = 5f * 60;
        private float timer;

        private void Awake()
        {
            //PlayerPrefs.DeleteAll();
            //Debug.LogError("Pause");

            if (PlayerPrefs.HasKey("HeartTimer"))
            {
                timer = PlayerPrefs.GetFloat("HeartTimer");
            }
            else
            {
                timer = 0f;
            }

            if (!PlayerPrefs.HasKey("CurrentHeart"))
            {
                PlayerPrefs.SetInt("CurrentHeart", 5);
            }

            if (PlayerPrefs.HasKey("ExitTime"))
            {
                //PlayerPrefs.SetString("AwakeTime", DateTime.Now.ToString("yyyyMMddHHmmss"));
                TimeSpan offlineTime = DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("ExitTime"));
                //float a = (float)offlineTime.TotalSeconds;
                PlayerPrefs.SetFloat("HeartTimer", (float)offlineTime.TotalSeconds);
                for (; PlayerPrefs.GetFloat("HeartTimer") >= standardTime;)
                {
                    if (PlayerPrefs.GetInt("CurrentHeart") >= 5)
                    {
                        timer = 0;
                        break;
                    }
                    PlayerPrefs.SetFloat("HeartTimer", PlayerPrefs.GetFloat("HeartTimer") - standardTime);
                    PlayerPrefs.SetInt("CurrentHeart", PlayerPrefs.GetInt("CurrentHeart") + 1);
                }
            }
        }

        private void Update()
        {
            //CoinUpdate();
            HeartUpdate();
        }

        private void CoinUpdate()
        {
            //최준이 게임매니저를 만든다 하였다
        }

        private void HeartUpdate()
        {
            if(PlayerPrefs.GetInt("CurrentHeart") >= 5)
            {
                return;
            }
            if(timer >= standardTime)
            {
                PlayerPrefs.SetInt("CurrentHeart", PlayerPrefs.GetInt("CurrentHeart") + 1);
                timer = 0;
            }

            m_heart.text = $"{PlayerPrefs.GetInt("CurrentHeart")} / 5";

            timer += Time.deltaTime;
        }
    }
}