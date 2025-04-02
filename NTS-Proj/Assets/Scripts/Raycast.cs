using System;
using System.Text;
using TMPro;
using UnityEngine;


public class Raycast : MonoBehaviour
{
    Camera cam;
    Ray ray;
    RaycastHit hit;

    [SerializeField] public TMP_Text ScoreDisplay;
    [SerializeField] public TMP_Text HPBar;
    [SerializeField] public GameObject ParticlePrefab;
    
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    
    public int Score = 0;
    public int Health = 10;
    private float winScore = 100;
    
 
    private void Start()
    {
        cam = Camera.main;
        ScoreDisplay.text = $"Score: \n0/{winScore}";
    }

    private void Update()
    {
        // Create a ray from the center of the screen
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

    }

    private void HealthUpdate()
    {
        Health -= 1;
        if (Health <= 0)
        {
            Health = 0;
            LosePanel.SetActive(true);
            Invoke(nameof(ReloadScene), 3f);
        }
        HPBar.text = "";
        for (int i = 0; i < Health; i++)
        {
            HPBar.text += "\u25a0";
        }
        HPBar.color = new Color(1, (float)(Health / 10.0 ), (float)(Health / 10.0 ));
    }
    
    private void ReloadScene()
    {
        var ui_manager = GameObject.FindGameObjectWithTag("UIManager");
        ui_manager.GetComponent<UI_Manager>().ReloadScene();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            HealthUpdate();
            var particle = Instantiate(ParticlePrefab, other.transform.position, Quaternion.identity);
            Destroy(particle, 1.5f);
            Destroy(other.gameObject);
        }
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
                Score += (int)(hit.distance*10);
                if (Score > winScore)
                {
                    WinPanel.SetActive(true);
                    Invoke(nameof(ReloadScene), 3f);
                }
                ScoreDisplay.text = $"Score:\n{Score}/1000";
                ScoreDisplay.color = new Color(1, 1, 1-(Score / winScore));
                var particle = Instantiate(ParticlePrefab, hit.collider.gameObject.transform.position, Quaternion.identity);
                Destroy(particle, 1.5f);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}