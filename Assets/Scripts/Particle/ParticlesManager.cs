using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Particles
{
    public class ParticlesManager : MonoBehaviour
    {
        public static ParticlesManager Instance {get; private set;}

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

        public void PlayBloodEffect(GameObject effectPrefab, Vector3 hitPosition, Vector3 attackerPosition){
            Vector3 direction = attackerPosition - hitPosition;
            direction.Normalize();
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            rotation = new Quaternion(0,rotation.y,0,rotation.w);
            ObjectPooling.InstantiateObject(effectPrefab, hitPosition, rotation);
        }

    }
}
