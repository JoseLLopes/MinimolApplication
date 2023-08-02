using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames
{
    public class EnemyAttack : MonoBehaviour
    {

        Vector3 rayOffSet = new Vector3(0,1f,0);
       
        void Update(){
            RaycastHit hit;
            
            if(Physics.Raycast(transform.position + rayOffSet,transform.forward, out hit, 0.8f)){

                if(hit.transform.TryGetComponent<IDamageable>(out var damageable)){
                    damageable.TakeDamage(1);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            // Draws a 5 unit long red line in front of the object
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position + rayOffSet,transform.forward*0.8f);
        }
    }
}
