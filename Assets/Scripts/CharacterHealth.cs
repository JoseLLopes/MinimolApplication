using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.Particles;

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
        [SerializeField]protected int Health;
        [SerializeField]protected int maxHealth;
        [SerializeField]GameObject hitEffect;
        void Start(){
            Health = maxHealth;
        }

        public virtual void TakeDamage(DamageData damageData)
        {
            if(Health > 0){
                Health -= damageData.amount;
                if(hitEffect)
                    ParticlesManager.Instance.PlayBloodEffect(hitEffect,damageData.damagePoint,damageData.attackerPosition);
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
