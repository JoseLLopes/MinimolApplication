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
        [SerializeField] PlayerHealth playerHealth;
        [SerializeField] Image healthBar;
        [SerializeField] TMP_Text killedEnemiesText;
        [SerializeField] WaveController waveController;
        int killedEnemies = 0;
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
