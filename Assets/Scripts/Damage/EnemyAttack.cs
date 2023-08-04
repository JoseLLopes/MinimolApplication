using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.DamageSystem;

namespace MinimolGames
{
    public class EnemyAttack : MonoBehaviour
    {
        Vector3 rayOffSet = new Vector3(0,1f,0);
        [SerializeField] int damage;
        float timeBetweenAttacks = 0;
        float lastAttackTime;
        [HideInInspector] public PlayerController player;

        void Start(){
            if(!player)
                player = PlayerController.Instance;
        }

        void Update(){
            if(!player)
            return;
            
            float targetDistance = Vector3.Distance(player.transform.position,transform.position);
            
            //Check if player is closer
            if(targetDistance > 1.1)
                return;

            if(timeBetweenAttacks == 0 && Time.time - lastAttackTime >= timeBetweenAttacks){
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
