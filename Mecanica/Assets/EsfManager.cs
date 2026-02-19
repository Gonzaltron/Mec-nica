using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EsfManager : MonoBehaviour
{
    public List<EsfForces> balls = new List<EsfForces>();
    public float xMin, xMax, yMin, yMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var b in balls) { 
            b.Resolve(Time.deltaTime);
            ResolveWallCollisions(b);
        }
    }

    void ResolveWallCollisions(EsfForces e)
    {
        Vector3 p3 = e.transform.position;
        Vector2 pos = new Vector2 (p3.x, p3.y);

        if(pos.x - e.rad < xMin)
        {
            pos.x = xMin + e.rad;
            e.vel.x = -e.vel.x;
        }else if(pos.x + e.rad > xMax)
        {
            pos.x = xMax - e.rad;
            e.vel.x = -e.vel.x;
        }

        if (pos.y + e.rad > yMax) { 
            pos.y = yMax - e.rad;
            e.vel.y = -e.vel.y;
        }else if(pos.y - e.rad < yMin)
        {
            pos.y = yMin + e.rad;
            e.vel.y= -e.vel.y;
        }

        e.transform.position = pos;
    }
}
