using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.InputEvents;
using System;

namespace MinimolGames.Movement
{
    public class PlayerDash : MonoBehaviour
    {

        [SerializeField] Rigidbody rb;
        [SerializeField] float dashDuration;

        void OnEnable(){
            PlayerInputEvents.OnDash += Dash;
        }

        void OnDisable(){
            PlayerInputEvents.OnDash -= Dash;
        }

        void Dash()
        {
            Vector3 dashDirection = new Vector3(PlayerInputEvents.horizontal,0,PlayerInputEvents.vertical); // Change this to the direction you want to dash towards

            rb.AddForce(dashDirection * 20, ForceMode.Impulse);
            StartCoroutine(StopDashTime());
        }

        IEnumerator StopDashTime(){
            yield return new WaitForSeconds(dashDuration);
            rb.velocity = Vector3.zero;
        }
    }
}
