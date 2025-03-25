using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    
    [Header("Spawn Settings")]
    public float timeBeforeStart = 5f;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 6f;

    private void Start()
    {
        StartCoroutine(InitSpawn());
    }

    private IEnumerator InitSpawn()
    {
        yield return new WaitForSeconds(timeBeforeStart);
        yield return Spawn();
    }
    
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Instantiate(prefab, RandomPositionInMeshBounds(mesh), Quaternion.identity);
        yield return Spawn();
    }
    
    private Vector3 RandomPositionInMeshBounds(Mesh mesh)
    {
        var bounds = mesh.bounds;
        var x = Random.Range(bounds.min.x, bounds.max.x);
        var z = Random.Range(bounds.min.z, bounds.max.z);
        return new Vector3(x, 0, z);
    }
}
