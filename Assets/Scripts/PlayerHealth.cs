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
        public UnityEvent onPlayerDie;

        public override void TakeDamage(DamageData damageData)
        {
            float passedTime = Time.time-lastDamageTime;

            //Guarantee that the player does not take too much damage in a short time
            if(lastDamageTime == 0 || passedTime >= timeBetweenDamages){
                lastDamageTime = Time.time;

                //Base of father TakeDamage Function
                base.TakeDamage(damageData);

                //Create DamageData isntance
                HealthData healthData = new HealthData(Health,maxHealth);
                onTakeDamage?.Invoke(healthData);
            }
        }

        protected override void Death()
        {
            onPlayerDie?.Invoke();
            base.Death();
        }
    }
}
