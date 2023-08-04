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
            EnemiesSoundController.Instance.PlayHitAudio(getHitAudioClip);
            base.TakeDamage(damageData);
        }

        protected override void Death(){
            WaveController.Instance.DefeatCreature(gameObject);
            ObjectPooling.DestroyObject(gameObject);
        }

    }
}
