using System;
using UnityEngine;
using System.Collections;

namespace MinimolGames
{
    public class Bullet : MonoBehaviour
    {

        [SerializeField] float timeToDesapear;
        
        void Start()
        {
            StartCoroutine(WaitToDestroy());
        }

        void Update()
        {
            transform.Translate(10f * Time.deltaTime * transform.forward, Space.World);

            RaycastHit hit;

            if(Physics.Raycast(transform.position,transform.forward, out hit, 10f * Time.deltaTime)){

                if(hit.transform.TryGetComponent<IDamageable>(out var damageable)){
                    damageable.TakeDamage(1);
                    ObjectPooling.DestroyObject(gameObject);
                }
            }
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