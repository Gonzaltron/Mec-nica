using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Gravity : MonoBehaviour
{
    const float gravityForce = 0.00001f;
    [SerializeField] float mass;
    public float mass2;
    [SerializeField] GameObject Object;
    GameObject[] objects;
    Vector3 force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        applyGravity();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 20);
    }

    public void applyGravity()
    {
        foreach (GameObject obj in objects)
        {
            mass2 = obj.GetComponent<data>().mass;
            Vector3 Distance = new Vector3(obj.transform.position.x - this.transform.position.x, obj.transform.position.y - this.transform.position.y, obj.transform.position.z - this.transform.position.z);
            float totalDistance = Mathf.Sqrt((Distance.x * Distance.x) + (Distance.y * Distance.y) + (Distance.z * Distance.z));
            Vector3 r = Distance / totalDistance;
            force = ((gravityForce * mass * mass2)/(totalDistance * totalDistance) * r);
            if(totalDistance < 20)
            {
                obj.transform.LookAt(force*-1);
                obj.GetComponent<Rigidbody>().AddForce((force* -1) * Time.deltaTime);
                force = Vector3.zero;
            }
        }
    }
}
