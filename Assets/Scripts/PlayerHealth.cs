using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.DamageSystem
{
    public class PlayerHealth : CharacterHealth
    {
        [SerializeField] float timeBetweenDamages;
        float lastDamageTime = 0;
        
        public override void TakeDamage(int amount)
        {
            float passedTime = Time.time-lastDamageTime;
            if(lastDamageTime == 0 || passedTime >= timeBetweenDamages){
                lastDamageTime = Time.time;
                base.TakeDamage(amount);
            }
        }
    }
}
