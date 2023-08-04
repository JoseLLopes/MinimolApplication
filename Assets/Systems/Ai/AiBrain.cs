using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MinimolGames.DamageSystem;
namespace MinimolGames
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;
        [SerializeField] Animator animator;
        [HideInInspector] public PlayerController player;
        [SerializeField] float attackDistance;
        [SerializeField] EnemyAttack enemyAttack;

        void Awake(){
            if(!player)
                player = PlayerController.Instance;
        }

        void FixedUpdate(){

            if (player == null) 
                return;

            float targetDistance = Vector3.Distance(player.transform.position,transform.position);
            
            if(targetDistance > attackDistance){
                agent.SetDestination(player.transform.position);
                animator.SetBool("moving",true);
            }
            else{
                enemyAttack.Attack();
                animator.SetBool("moving",false);
            }
        }

    }
}
