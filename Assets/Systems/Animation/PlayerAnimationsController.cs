using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.InputEvents;

namespace MinimolGames.Animations
{
    public class PlayerAnimationsController : MonoBehaviour
    {
        [SerializeField] Animator animator;

        void FixedUpdate(){
            
            Vector3 forwardDirection = transform.forward;

            
            float verticalAxisValue = Vector3.Dot(forwardDirection, new Vector3(PlayerInputEvents.horizontal, 0, PlayerInputEvents.vertical));
            float horizontalAxisValue = Vector3.Dot(forwardDirection, new Vector3(PlayerInputEvents.vertical, 0, -PlayerInputEvents.horizontal));

            animator.SetFloat("vertical", verticalAxisValue);
            animator.SetFloat("horizontal", -horizontalAxisValue);
        }
    }
}
