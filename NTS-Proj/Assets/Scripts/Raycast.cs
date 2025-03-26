using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Raycast : MonoBehaviour
{
    Camera cam;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        // Create a ray from the center of the screen
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

    }

    public void Shot()
    {
        // Create a ray from the center of the screen
        ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        
        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // Print the name of the object that was hit
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Zombie"))
            {
                Destroy(hit.collider.gameObject);
            }
        }   
    }
}