using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.DamageSystem;

namespace MinimolGames.Ai
{
    public class AiMeleeAttack : AiState
    {
        [SerializeField] AiChase aiChase;
        Vector3 rayOffSet = new Vector3(0,1f,0);
        [SerializeField] int damage;
        [SerializeField] float timeBetweenAttacks;
        float lastAttackTime = 0;

        public override AiState RunCurrentState()
        {
            return Attack();
        }

        public AiState Attack(){

            if(lastAttackTime == 0 || Time.time - lastAttackTime >= timeBetweenAttacks){
                lastAttackTime = Time.time;

                RaycastHit hit;
                
                if(Physics.Raycast(transform.position + rayOffSet,transform.forward, out hit, 1f)){
                    
                    //Check if hit something damageable and if not is me or friend
                    if(hit.transform.TryGetComponent<IDamageable>(out var damageable) && !hit.transform.CompareTag(transform.tag)){
                        DamageData damageData = new DamageData(damage,hit.point,transform.position);
                        damageable.TakeDamage(damageData);
                    }
                }
            }
            return aiChase;
        }

        
    }
}
