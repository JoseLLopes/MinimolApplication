using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MinimolGames.Audio;

namespace MinimolGames.DamageSystem
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField]protected float Health;
        [SerializeField]protected float maxHealth;

        void Start(){
            Health = maxHealth;
        }

        public virtual void TakeDamage(int amount)
        {
            if(Health > 0){
                Health -= amount;
                EnemiesSoundController.Instance.PlayHitAudio();
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
