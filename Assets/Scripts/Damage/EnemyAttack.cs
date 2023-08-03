using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.DamageSystem;

namespace MinimolGames
{
    public class EnemyAttack : MonoBehaviour
    {
        Vector3 rayOffSet = new Vector3(0,1f,0);
        EnemyController enemyController;
        [SerializeField] float timeBetweenAttacks = 0;
        float lastAttackTime;

        void Start(){
            enemyController = GetComponent<EnemyController>();
        }

        void Update(){
            float targetDistance = Vector3.Distance(enemyController.player.transform.position,transform.position);
            
            //Check if player is closer
            if(targetDistance > 1.1)
                return;

            if(timeBetweenAttacks == 0 && Time.time - lastAttackTime >= timeBetweenAttacks){
                RaycastHit hit;
                
                if(Physics.Raycast(transform.position + rayOffSet,transform.forward, out hit, 0.8f)){

                    if(hit.transform.TryGetComponent<IDamageable>(out var damageable) && !hit.transform.CompareTag(transform.tag)){
                        damageable.TakeDamage(1);
                    }
                }
            }
        }

    }
}
