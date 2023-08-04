using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MinimolGames.InputEvents
{
    public class PlayerInputEvents : MonoBehaviour
    {
        
        PlayerInputActions inputActions;

        //MOVEMENT
        public static float horizontal;
        public static float vertical;

        //SHOOT
        bool isShooting = false;
        public delegate void ShootAction();
        public static event ShootAction OnShoot;

        void Awake(){
            inputActions = new PlayerInputActions();
            inputActions.Enable();
            inputActions.Player.Shoot.performed += ShootPerformed;
            inputActions.Player.Shoot.canceled += ShootCancel;
        }

        void Update(){

            if(OnShoot != null && isShooting)
                OnShoot();
        }

        void FixedUpdate(){
            horizontal = inputActions.Player.Movement.ReadValue<Vector2>().x;
            vertical = inputActions.Player.Movement.ReadValue<Vector2>().y;
        }

        //SHOOT
        private void ShootCancel(InputAction.CallbackContext context)
        {
            isShooting = false;
        }

        private void ShootPerformed(InputAction.CallbackContext context)
        {
            isShooting = true;
        }

    }
}
