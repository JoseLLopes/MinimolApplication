using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MinimolGames.DamageSystem
{


    public class PlayerHealth : CharacterHealth
    {
        [SerializeField] float timeBetweenDamages;
        float lastDamageTime = 0;
        [HideInInspector] public UnityEvent<HealthData> onTakeDamage;

        public override void TakeDamage(DamageData damageData)
        {
            float passedTime = Time.time-lastDamageTime;

            if(lastDamageTime == 0 || passedTime >= timeBetweenDamages){
                lastDamageTime = Time.time;

                //Base of father TakeDamage Function
                base.TakeDamage(damageData);

                //Create DamageData isntance
                HealthData healthData = new HealthData(Health,maxHealth);
                onTakeDamage?.Invoke(healthData);
            }
        }

        
    }
}
