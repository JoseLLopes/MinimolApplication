using System;
using UnityEngine;
using System.Collections;
using MinimolGames.DamageSystem;

namespace MinimolGames
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] float timeToDesapear;
        [SerializeField] float speed = 10f;
        [SerializeField] int damage;
        
        void OnEnable()
        {
            StartCoroutine(WaitToDestroy());
        }

        void FixedUpdate()
        {

            RaycastHit hit;

            if(Physics.Raycast(transform.position,transform.forward, out hit, speed * 2 * Time.deltaTime)){

                if(hit.transform.TryGetComponent<IDamageable>(out var damageable)){
                    DamageData damageData = new DamageData(damage,transform.position);
                    damageable.TakeDamage(damageData);
                    ObjectPooling.DestroyObject(gameObject);
                }
            }
            transform.Translate(speed * Time.deltaTime * transform.forward, Space.World);
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