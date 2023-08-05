using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.Audio;

namespace MinimolGames.DamageSystem
{
    public class DamageableObject : CharacterHealth
    {

        [SerializeField] GameObject destructedObject;
        [SerializeField] AudioClip destructionAudioClip;

        protected override void Death(){
            SoundManager.Instance.Play(destructionAudioClip);
            destructedObject.transform.parent = null;
            destructedObject.SetActive(true);
            this.gameObject.SetActive(false);
        }


    }
}