using UnityEngine;
using System.Collections;

namespace MinimolGames
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] Transform spawnPoint;
        [SerializeField] float shootSpeedRate;
        bool canShoot = true;
        void Update()
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                canShoot = false;
                StartCoroutine(Shoot());
            }
        }

        IEnumerator Shoot(){
            ObjectPooling.InstantiateObject(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(shootSpeedRate);
            canShoot = true;

        }
    }
}