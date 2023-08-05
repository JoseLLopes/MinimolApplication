using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Ai
{
    public class AiStateMachine : MonoBehaviour
    {
        [SerializeField] AiState currentState;

        void Update(){
            RunStateMachine();
        }

        void RunStateMachine(){
            AiState nextState = currentState?.RunCurrentState();

            if(nextState != null){
                SwitchToTheNextState(nextState);
            }
        }

        void SwitchToTheNextState(AiState nextState){
            currentState = nextState;
        }

    }
}
