using UnityEngine;
using System.Collections;

namespace MinimolGames
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform spawnPoint;
        [SerializeField] float rateOfFire;
        bool canShoot = true;
        
        [Header("Sound")]
        [SerializeField] AudioClip shootSound;
        [SerializeField] AudioSource audioSource;
        

        void Update()
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                canShoot = false;
                StartCoroutine(Shoot());
            }
        }

        IEnumerator Shoot(){
            audioSource.PlayOneShot(shootSound);
            ObjectPooling.InstantiateObject(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(rateOfFire);
            canShoot = true;

        }
    }
}