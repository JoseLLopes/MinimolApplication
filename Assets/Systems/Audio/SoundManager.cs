using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Audio
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;
        public static SoundManager Instance {get; private set;}

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

        public void Play(AudioClip getHit){
            audioSource.PlayOneShot(getHit);
        }

    }
}
