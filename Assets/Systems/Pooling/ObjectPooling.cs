using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPooling : MonoBehaviour
{
    
    public static GameObject objectPoolingContainer;
    public static List<Pool> poolingRoots = new List<Pool>();

    
    void Start(){
        objectPoolingContainer = new GameObject("Pool Container");
    }

    public static GameObject InstantiateObject(GameObject obj, Vector3 position, Quaternion rotation){
        
        GameObject spawnObject;
        Pool currentPool = poolingRoots.Find(p=> p.poolName == obj.name);

        if(currentPool == null){
            currentPool = new GameObject(obj.name).AddComponent<Pool>();
            currentPool.transform.parent = objectPoolingContainer.transform;
            currentPool.poolName = obj.name;

            poolingRoots.Add(currentPool);
        }

        spawnObject = currentPool.objectsInPool.FirstOrDefault();

        if(spawnObject == null){
            spawnObject = Instantiate(obj, currentPool.transform);
        }
        currentPool.objectsInPool.Remove(spawnObject);
        spawnObject.transform.position = position;
        spawnObject.transform.rotation = rotation;
        spawnObject.SetActive(true);

        return spawnObject;
    }

    public static void DestroyObject(GameObject obj){
        string poolName = obj.name.Substring(0, obj.name.Length - 7); //removing (clone) name
        Pool currentPool = poolingRoots.Find(p=> p.poolName == poolName);

        if(currentPool){
            obj.SetActive(false);
            currentPool.objectsInPool.Add(obj);
        }else{
            Destroy(obj);
        }
    }    

}
