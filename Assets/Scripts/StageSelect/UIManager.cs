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
        [SerializeField] private TextMeshProUGUI m_playerName;

        private SaveAPSystem apSaveSystem;
        private float standardTime = 5f * 60;
        private float timer;

        //private void Awake()
        //{
        //    SetAP();
        //}

        private void Start()
        {
            apSaveSystem = this.gameObject.GetComponent<SaveAPSystem>();
            apSaveSystem.LoadFromJson();
            SetAP();
            m_heart.text = $"{apSaveSystem.apInfo.currentHeart} / 5";
            m_playerName.text = SavePlayerInfo.instance.playerInfo.playerName;
        }

        private void Update()
        {
            CoinUpdate();
            HeartUpdate();
        }

        private void OnApplicationQuit()
        {
            SetExitMode();
        }

        private void CoinUpdate()
        {
            int tempCoin;
            if(!int.TryParse(m_coin.text, out tempCoin))
            {
                Debug.LogError("CoinSystemError");
            }
            if(tempCoin != SavePlayerInfo.instance.playerInfo.playerGold)
            {
                m_coin.text = SavePlayerInfo.instance.playerInfo.playerGold.ToString();
            }
        }

        private void HeartUpdate()
        {
            if(apSaveSystem.apInfo.currentHeart >= 5)
            {
                return;
            }
            if(timer >= standardTime)
            {
                apSaveSystem.apInfo.currentHeart++;
                m_heart.text = $"{apSaveSystem.apInfo.currentHeart} / 5";
                timer = 0;
            }
            timer += Time.deltaTime;
        }

        private void SetAP()
        {
            timer = apSaveSystem.apInfo.timer;

            //if (!PlayerPrefs.HasKey("CurrentHeart"))
            //{
            //    PlayerPrefs.SetInt("CurrentHeart", 5);
            //}

            //if (PlayerPrefs.HasKey("ExitTime"))
            if(apSaveSystem.apInfo.exitTime != null)
            {
                TimeSpan offlineTime = DateTime.Now - apSaveSystem.apInfo.exitTime;
                apSaveSystem.apInfo.timer += (float)offlineTime.TotalSeconds;
                for(; apSaveSystem.apInfo.timer >= standardTime;)
                {
                    if(apSaveSystem.apInfo.currentHeart >= 5)
                    {
                        timer = 0;
                        break;
                    }
                    apSaveSystem.apInfo.timer -= standardTime;
                    apSaveSystem.apInfo.currentHeart += 1;
                }
            }
        }

        public void SetExitMode()
        {
            apSaveSystem.apInfo.timer = timer;
            apSaveSystem.apInfo.exitTime = DateTime.Now;
            apSaveSystem.SaveToJson();
        }
    }
}