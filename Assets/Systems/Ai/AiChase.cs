using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MinimolGames.Ai
{
    public class AiChase : AiState
    {
        [SerializeField] AiMeleeAttack aiAttack;
        [SerializeField] NavMeshAgent agent;
        [SerializeField] float aproachDistance;
        [SerializeField] Animator animator;
        [HideInInspector] public PlayerController player;

         void Awake(){
            if(!player)
                player = PlayerController.Instance;
        }

        public override AiState RunCurrentState()
        {
            if (player == null) 
                return this;

            float targetDistance = Vector3.Distance(player.transform.position,agent.transform.position);
            transform.LookAt(player.transform.position);

            //If Player is closer
            if(targetDistance > aproachDistance){
                agent.SetDestination(player.transform.position);
                animator.SetBool("moving",true);
                return this;
            }
            else{
                //Attack
                animator.SetBool("moving",false);
                return aiAttack;
            }
        }
    }
}
