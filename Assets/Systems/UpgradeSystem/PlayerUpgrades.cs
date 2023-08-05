using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.PlayerShoot;
using MinimolGames.Movement;

namespace MinimolGames.UpgradeSystem
{
    public class PlayerUpgrades : MonoBehaviour
    {
        [SerializeField] WeaponController playerWeapon;
        [SerializeField] PlayerController playerMovement;
        [SerializeField] PlayerDash playerDash;

        void ImproveFireRate(float value){
            playerWeapon.rateOfFire = value;
        }

        void ChangeBullet(Bullet bulletPrefab){
            playerWeapon.bulletPrefab = bulletPrefab.gameObject;
        }

        void ImprovePlayerSpeed(float value){
            playerMovement.speedMultiplyer = value;
        }

        void ImproveDashCoolDown(float value){
            playerDash.dashCooldown = value;
        }
        
    }
}
