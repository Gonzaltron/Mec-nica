using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class PartilucaManager : MonoBehaviour
{
    [SerializeField] Prticula particula;
    [SerializeField] GameObject particulaPrefab;
    [SerializeField] int maxParticles;
    [SerializeField] List<GameObject> particles = new List<GameObject> { };
    bool isPooling = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particula.force.x = Random.Range(1f, 3f);
        particula.force.y = -5f;
        particula.force.z = Random.Range(1f, 3f);
        particula.speed.x = Random.Range(1f, 3f);
        particula.speed.y = 4f;
        particula.speed.z = Random.Range(1f, 3f);
        particula.mass = Random.Range(0.5f, 122f);

        for (int i = 0; i < maxParticles; i++)
        {
            transform.position = new Vector3(0, 0, 0);
            GameObject particulas = GameObject.Instantiate(particulaPrefab, transform.position, Quaternion.identity);
            particles.Add(particulas);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(particula.speed.y >0)
        {
            particula.speed.y = particula.speed.y * -1;
        }
        if (isPooling == false)
        {
            StartCoroutine(Pooling());
        }
    }

    IEnumerator Pooling()
    {
        Debug.Log("pul");
        isPooling = true;
        for (int i = 0; i < particles.Count; i++)
        {
            yield return new WaitForSeconds(1);
            particles[i].SetActive(false);
            particles[i].transform.position = new Vector3(0, 0, 0);
            particles[i].SetActive(true);
        }
        isPooling = false;
    }
}
