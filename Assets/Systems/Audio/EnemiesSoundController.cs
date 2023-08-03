using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Audio
{
    public class EnemiesSoundController : MonoBehaviour
    {
        [SerializeField] AudioClip getHit;
        [SerializeField] AudioSource audioSource;
        public static EnemiesSoundController Instance {get; private set;}

        void Awake(){
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayHitAudio(){
            audioSource.PlayOneShot(getHit);
        }

    }
}
