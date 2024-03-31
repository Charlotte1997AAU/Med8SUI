using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWeapon : MonoBehaviour
{
    public GameObject prefabToSpawn; 
    public Transform targetObject;  

    void Start()
    {
        SpawnAndPlacePrefab();
    }

    void SpawnAndPlacePrefab()
    {
        if (prefabToSpawn != null && targetObject != null)
        {
            
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, targetObject.position, Quaternion.identity);


            Bounds targetBounds = targetObject.GetComponent<Renderer>().bounds;

            Vector3 newPosition = new Vector3(targetBounds.center.x,
                                               targetBounds.max.y + spawnedPrefab.transform.localScale.y / 2, // Place it on top of the target object
                                               targetBounds.center.z);

            spawnedPrefab.transform.position = newPosition;
        }
      
    }
}
