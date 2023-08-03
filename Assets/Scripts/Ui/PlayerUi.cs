using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MinimolGames.DamageSystem;

namespace MinimolGames.UI
{
    public class PlayerUi : MonoBehaviour
    {
        [SerializeField] PlayerHealth playerHealth;
        [SerializeField] Image healthBar;

        void OnEnable(){
            if(!playerHealth)
                playerHealth = PlayerController.Instance.GetComponent<PlayerHealth>();
            playerHealth.onTakeDamage.AddListener(UpdatePlayerLife);
        }

        void OnDisable(){
            playerHealth.onTakeDamage.RemoveListener(UpdatePlayerLife);
        }

        void UpdatePlayerLife(HealthData healthData){
            healthBar.fillAmount = (float)healthData.currentHealth / (float)healthData.maxHealth;
        }
    }
}
