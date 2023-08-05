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


        void OnEnable(){
            if(!playerHealth)
                playerHealth = PlayerController.Instance.GetComponent<PlayerHealth>();
            playerHealth.onTakeDamage.AddListener(UpdatePlayerLife);
            waveController.onDefeatCreature.AddListener(UpdateKilledEnemies);
        }

        void OnDisable(){
            playerHealth.onTakeDamage.RemoveListener(UpdatePlayerLife);
            waveController.onDefeatCreature.RemoveListener(UpdateKilledEnemies);
        }

        void UpdatePlayerLife(HealthData healthData){
            healthBar.fillAmount = (float)healthData.currentHealth / (float)healthData.maxHealth;
        }

        void UpdateKilledEnemies(){
            killedEnemies++;
            killedEnemiesText.text = ""+killedEnemies;
        }

    }
}
