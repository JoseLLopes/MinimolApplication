using System;
using UnityEngine;
using System.Collections;
using MinimolGames.DamageSystem;

namespace MinimolGames.PlayerShoot
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] float timeToDesapear;
        [SerializeField] float speed = 10f;
        [SerializeField] int damage;
        [SerializeField] GameObject hitDefaultEffect;

        void OnEnable()
        {
            StartCoroutine(WaitToDestroy());
        }

        void FixedUpdate()
        {

            RaycastHit hit;

            if(Physics.Raycast(transform.position,transform.forward, out hit, speed * 2 * Time.deltaTime)){

                //if hit something damageable
                if(hit.transform.TryGetComponent<IDamageable>(out var damageable)){
                    DamageData damageData = new DamageData(damage,hit.point,transform.position);
                    damageable.TakeDamage(damageData);
                    
                }
                //if not damageable
                else{
                    HitDefault(hit.point);
                }
                ObjectPooling.DestroyObject(gameObject);
            }

            transform.Translate(speed * Time.deltaTime * transform.forward, Space.World);
        }

        void HitDefault(Vector3 hitPosition){
            ObjectPooling.InstantiateObject(hitDefaultEffect, hitPosition, transform.rotation);
        }

        IEnumerator WaitToDestroy(){
            yield return new WaitForSeconds(timeToDesapear);
            ObjectPooling.DestroyObject(gameObject);
        }

        /*void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }*/
    }
}