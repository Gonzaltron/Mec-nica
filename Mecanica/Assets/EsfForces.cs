using System.Net.Sockets;
using UnityEngine;

public class EsfForces : MonoBehaviour
{
    public Vector2 vel;
    [SerializeField] float mass = 1;
    [SerializeField] Vector2 forceAccum;
    public float rad = 1;


    private void Update()
    {
        //Resolve(Time.deltaTime);
    }

    public void Resolve(float dt) { 
        Vector2 p = new Vector2(transform.position.x, transform.position.y);
        p = p + vel;
        // F = m*a
        Vector2 a = forceAccum/mass;
        //Vel = acc* deltaTime
        vel += a * dt;
        transform.position = new Vector3(p.x, p.y, 0);
        forceAccum = Vector2.zero;
               
    }
    
}
