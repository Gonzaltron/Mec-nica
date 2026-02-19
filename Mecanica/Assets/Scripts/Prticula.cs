using System.Collections;
using UnityEngine;

public class Prticula : MonoBehaviour
{
    [SerializeField]public Vector3 speed;
    public Vector3 acceleration;
    [SerializeField] public float mass;
    public Vector3 force;
    [SerializeField] public float lifeTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        acceleration.x = force.x / mass;
        acceleration.y = force.y / mass;
        acceleration.z = force.z / mass;
        speed.x = speed.x + acceleration.x * Time.deltaTime;
        speed.y = speed.y + acceleration.y * Time.deltaTime;
        speed.z = speed.z + acceleration.z * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + speed.x * Time.deltaTime, transform.position.y + speed.y * Time.deltaTime, transform.position.z + speed.z * Time.deltaTime);
        //force = Vector3.zero;
    }
}
