using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.InputEvents;
using System;
using MinimolGames.Audio;

namespace MinimolGames.Movement
{
    public class PlayerDash : MonoBehaviour
    {

        [SerializeField] Rigidbody rb;
        [SerializeField] float dashDuration;
        [SerializeField] AudioClip dashSound;
        [SerializeField] float dashCooldown;
        float lastDashTime = 0;

        void OnEnable(){
            PlayerInputEvents.OnDash += DashPerformed;
        }

        void OnDisable(){
            PlayerInputEvents.OnDash -= DashPerformed;
        }

        void DashPerformed()
        {
            float passedTime = Time.time - lastDashTime;
            if(lastDashTime == 0  || passedTime >= dashCooldown){
                lastDashTime = Time.time;
                StartCoroutine(DoDash());
            }
        }

        IEnumerator DoDash(){

            Vector3 dashDirection = new Vector3(PlayerInputEvents.horizontal,0,PlayerInputEvents.vertical);
            SoundManager.Instance.Play(dashSound);
            rb.AddForce(dashDirection * 20, ForceMode.Impulse);

            yield return new WaitForSeconds(dashDuration);
            rb.velocity = Vector3.zero;
        }
    }
}
