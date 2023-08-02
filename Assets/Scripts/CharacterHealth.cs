using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] float Health;
        [SerializeField] float maxHealth;

        void Start(){
            Health = maxHealth;
        }

        public void TakeDamage(int amount)
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
