using UnityEngine;

public class data : MonoBehaviour
{
    [SerializeField] public float mass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mass = Random.Range(10, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
