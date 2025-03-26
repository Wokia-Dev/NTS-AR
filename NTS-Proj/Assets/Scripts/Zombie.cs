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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        // Instantiate a particle effect and destroy it after 2 seconds
        var particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        Destroy(particle, 2f);
    }
}
