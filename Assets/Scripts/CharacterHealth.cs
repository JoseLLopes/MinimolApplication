using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace MinimolGames.DamageSystem
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] float Health;
        [SerializeField] float maxHealth;

        void Start(){
            Health = maxHealth;
        }

        public virtual void TakeDamage(int amount)
        {
            if(Health > 0){
                Health -= amount;
            }
            if(Health <= 0){
                Death();
            }
        }

        void Death(){
            Destroy(gameObject);
        }
    }
}
