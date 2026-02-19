using UnityEngine;

public class MovimientoAngular : MonoBehaviour
{
    Vector3 angularVelocity;
    Vector3 angularAcceleration;
    float accelerationStrength = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angularAcceleration = Vector3.zero;
        if(Input.GetKeyDown(KeyCode.A))
        {
            angularAcceleration.x += accelerationStrength;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            angularAcceleration.x -= accelerationStrength;
        }
        Integrate(Time.deltaTime);
    }

    void Integrate(float dt)
    {
        angularVelocity += angularAcceleration * dt;
        transform.Rotate(angularVelocity * dt);
    }
}
