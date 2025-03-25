using UnityEngine;

public class Base_Monster_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Camera.main.transform.position, speed * Time.deltaTime);
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, 10, Camera.main.transform.position.z);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
}
