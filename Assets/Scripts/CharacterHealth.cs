using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.Utils;
using MinimolGames.Audio;

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

    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        protected int Health;
        [SerializeField]protected int maxHealth;
        [SerializeField]GameObject hitEffect;
        [SerializeField]AudioClip getHitSound;
        void Start(){
            Health = maxHealth;
        }

        public virtual void TakeDamage(DamageData damageData)
        {
            if(Health > 0){
                Health -= damageData.amount;
                if(hitEffect){
                    var hitRotation = EffectUtils.CalculateRotationByDamageDirection(damageData.damagePoint, damageData.attackerPosition);
                    ObjectPooling.InstantiateObject(hitEffect, damageData.damagePoint, hitRotation);
                }
                if(getHitSound)
                    SoundManager.Instance.Play(getHitSound);
            }
            if(Health <= 0){
                Death();
            }
        }

        protected virtual void Death(){
            Destroy(gameObject);
        }
    }
}
