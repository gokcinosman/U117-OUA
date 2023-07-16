using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject Grabbable;
    public Transform spawnPoint;
    
    private void Start()
    {
        // Delay the spawning of the key item
        Invoke("SpawnKey", 15f);
    }
    
    private void SpawnKey()
    {
        // Instantiate the key item prefab at the spawn point
        Instantiate(Grabbable, spawnPoint.position, spawnPoint.rotation);
    }
}

