using System;
using UnityEngine;

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
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
}