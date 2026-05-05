using UnityEngine;

public class SPIN : MonoBehaviour
{

    Rigidbody2D body;

    public float angularVelocity = 0;
    public float startAngle = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.rotation = startAngle;
        body.angularVelocity = angularVelocity;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
