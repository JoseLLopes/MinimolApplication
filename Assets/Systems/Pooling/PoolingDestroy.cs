using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingDestroy : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 2f;

    void Start()
    {
        StartCoroutine("AutoDestroy");
    }

    IEnumerator AutoDestroy(){
        yield return new WaitForSeconds(timeToDestroy);
        ObjectPooling.DestroyObject(gameObject);
    }
}
