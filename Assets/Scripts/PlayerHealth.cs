using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MinimolGames.DamageSystem
{

    [System.Serializable]
    public class HealthData
    {
        public int maxHealth;
        public int currentHealth;

        public HealthData(int currentHealth, int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth;
        }
    }


    public class PlayerHealth : CharacterHealth
    {
        [SerializeField] float timeBetweenDamages;
        float lastDamageTime = 0;
        [HideInInspector] public UnityEvent<HealthData> onTakeDamage;

        public override void TakeDamage(int amount, Vector3 damagePoint)
        {
            float passedTime = Time.time-lastDamageTime;

            if(lastDamageTime == 0 || passedTime >= timeBetweenDamages){
                lastDamageTime = Time.time;

                //Base of father TakeDamage Function
                base.TakeDamage(amount,damagePoint);

                //Create DamageData isntance
                HealthData healthData = new HealthData(Health,maxHealth);
                onTakeDamage?.Invoke(healthData);
            }
        }

        
    }
}
