using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.DamageSystem;
using MinimolGames.Audio;

namespace MinimolGames.WaveSystem
{
    public class WaveEvemy : CharacterHealth
    {       

        void OnEnable(){
            Health = maxHealth;
        }

        protected override void Death(){
            WaveController.Instance.DefeatCreature(gameObject);
            ObjectPooling.DestroyObject(gameObject);
        }

    }
}
