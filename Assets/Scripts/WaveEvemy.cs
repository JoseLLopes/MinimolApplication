using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.DamageSystem;
using MinimolGames.Audio;

namespace MinimolGames.WaveSystem
{
    public class WaveEvemy : CharacterHealth
    {       
        [SerializeField] AudioClip getHitAudioClip;

        void OnEnable(){
            Health = maxHealth;
        }

        public override void TakeDamage(DamageData damageData){
            SoundManager.Instance.Play(getHitAudioClip);
            base.TakeDamage(damageData);
        }

        protected override void Death(){
            WaveController.Instance.DefeatCreature(gameObject);
            ObjectPooling.DestroyObject(gameObject);
        }

    }
}
