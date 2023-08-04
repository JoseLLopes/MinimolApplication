using UnityEngine;
using MinimolGames.Movement;
using MinimolGames.InputEvents;

namespace MinimolGames
{
    public class PlayerController : CharacterMovement
    {
        public static PlayerController Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        
        void FixedUpdate()
        {
            Vector3 input = new Vector3(PlayerInputEvents.horizontal, 0, PlayerInputEvents.vertical);
            if (input == Vector3.zero) return;
            Move(input);
            
        }
    }
}
