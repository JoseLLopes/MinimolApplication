using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Movement
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 5f;
        
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Rotate(hit);
            }

        }

        void Rotate(RaycastHit hit)
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f; // To prevent tilting up or down

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
