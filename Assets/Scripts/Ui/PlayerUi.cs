using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MinimolGames.DamageSystem;
using MinimolGames.WaveSystem;
using TMPro;

namespace MinimolGames.UI
{
    public class PlayerUi : MonoBehaviour
    {
        [Header("Player Info")]
        PlayerHealth playerHealth;
        [SerializeField] Image healthBar;
        [SerializeField] TMP_Text killedEnemiesText;

        [Header ("Wave Info")]
        [SerializeField] WaveController waveController;
        int killedEnemies = 0;
        [SerializeField] TMP_Text currentWaveText;
        [SerializeField] TMP_Text totalWaveEnemiesText;

        [Header ("Finish Game")]
        [SerializeField] GameObject playerDiePanel;
        [SerializeField] GameObject endWavesPanel;
        
        void OnEnable(){
            if(!playerHealth)
                playerHealth = PlayerController.Instance.GetComponent<PlayerHealth>();
            playerHealth.onTakeDamage.AddListener(UpdatePlayerLife);
            playerHealth.onPlayerDie.AddListener(ShowDiePanel);
            waveController.onDefeatCreature.AddListener(UpdateKilledEnemies);
            waveController.onWaveChange.AddListener(UpdateWaveInfo);
            waveController.onFinishAllWaves.AddListener(ShowFinishWavePanel);
        }

        void OnDisable(){
            playerHealth.onTakeDamage.RemoveListener(UpdatePlayerLife);
            playerHealth.onPlayerDie.RemoveListener(ShowDiePanel);
            waveController.onDefeatCreature.RemoveListener(UpdateKilledEnemies);
            waveController.onWaveChange.RemoveListener(UpdateWaveInfo);
            waveController.onFinishAllWaves.RemoveListener(ShowFinishWavePanel);
        }

        void UpdatePlayerLife(HealthData healthData){
            healthBar.fillAmount = (float)healthData.currentHealth / (float)healthData.maxHealth;
        }

        void ShowDiePanel(){
            playerDiePanel.SetActive(true);
        }

        void ShowFinishWavePanel(){
            endWavesPanel.SetActive(true);
        }

        void UpdateKilledEnemies(){
            killedEnemies++;
            killedEnemiesText.text = ""+killedEnemies;
        }

        void UpdateWaveInfo(){
            currentWaveText.text = "Wave: "+waveController.currentWave+1;
            int amountOfEnemies = waveController.wavesSettings.waveList[waveController.currentWave].creaturesAmount;
            totalWaveEnemiesText.text =  amountOfEnemies+" Creatures";
        }

    }
}
