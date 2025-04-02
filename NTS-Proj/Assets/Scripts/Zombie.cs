using System;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject particlePrefab;
    
    Camera cam;
    public float speed = 1f;

    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cam.transform.position, Time.deltaTime * speed);
        transform.LookAt(cam.transform);
    }
}
