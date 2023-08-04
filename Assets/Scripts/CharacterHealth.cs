using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.DamageSystem
{
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
                    ObjectPooling.InstantiateObject(hitEffect, damageData.damagePoint, transform.rotation);
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
