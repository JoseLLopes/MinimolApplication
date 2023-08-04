using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Movement
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]protected float speed;
    
        CharacterController characterController;

        virtual protected void Start(){
        
            characterController = GetComponent<CharacterController>();
        }

        protected void Move(Vector3 input)
        {
            transform.Translate(speed * Time.deltaTime * input, Space.World);
        }
    }
}
