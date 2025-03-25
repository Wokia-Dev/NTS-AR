using System;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Camera cam;
    public float speed = 1f;

    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cam.transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
}
