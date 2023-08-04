using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.DamageSystem
{
    public class EnemyAttack : MonoBehaviour
    {
        Vector3 rayOffSet = new Vector3(0,1f,0);
        [SerializeField] int damage;
        float timeBetweenAttacks = 0;
        float lastAttackTime;

        public void Attack(){

            if(timeBetweenAttacks == 0 && Time.time - lastAttackTime >= timeBetweenAttacks){
                lastAttackTime = Time.time;

                RaycastHit hit;
                
                if(Physics.Raycast(transform.position + rayOffSet,transform.forward, out hit, 0.8f)){
                    if(hit.transform.TryGetComponent<IDamageable>(out var damageable) && !hit.transform.CompareTag(transform.tag)){
                        DamageData damageData = new DamageData(damage,hit.point,transform.position);
                        damageable.TakeDamage(damageData);
                    }
                }
            }
        }

    }
}
