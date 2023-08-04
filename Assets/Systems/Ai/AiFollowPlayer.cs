using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MinimolGames
{
    public class AiFollowPlayer : MonoBehaviour
    {
        [SerializeField] NavMeshAgent agent;

        [HideInInspector] public PlayerController player;

        void Awake(){
            if(!player)
                player = PlayerController.Instance;
        }

        void FixedUpdate(){
            if (player == null) 
                return;
            agent.SetDestination(player.transform.position);
        }
    }
}
