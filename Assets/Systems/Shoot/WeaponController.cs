using UnityEngine;
using System.Collections;
using MinimolGames.Audio;
using MinimolGames.InputEvents;

namespace MinimolGames.PlayerShoot
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform spawnPoint;
        [SerializeField] float rateOfFire;
        bool canShoot = true;
        PlayerInputEvents inputEvents;

        [Header("Sound")]
        [SerializeField] AudioClip shootSound;
        

        void OnEnable()
        {
            PlayerInputEvents.OnShoot += Shoot;
        }

        void OnDisable(){
            PlayerInputEvents.OnShoot -= Shoot;
        }

        void Shoot(){
            if(canShoot){
                canShoot = false;
                SoundManager.Instance.Play(shootSound);
                ObjectPooling.InstantiateObject(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(waitToShoot());
            }
        }

        IEnumerator waitToShoot(){
            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;
        }
    }
}