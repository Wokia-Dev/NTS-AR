using System;
using System.Collections;
using UnityEngine;

public class PlaneManagerSpawn : MonoBehaviour
{
    public GameObject[] planes;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        // gets with tags
        var newPlanes = GameObject.FindGameObjectsWithTag("Plane");
        planes = newPlanes;
        yield return Start();
    }
}
