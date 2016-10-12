using UnityEngine;
using System.Collections;

public class SphereCreation : MonoBehaviour
{
    public int np = 50;
    public int nm = 800;
    public float radius = 5.0F;
    public bool shrink = true;
    float dynamicTime = 0;
    float currentTime = 0;
    float previousTime = 0;
    float TimeLapse = 3;

    // Use this for initialization
    void Start()
    {
        GameObject[] halfCirc = makeHalfCircle(np, radius);
        //makeSphere(halfCirc, nm, np);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        Debug.Log(dynamicTime);
        dynamicTime = currentTime - previousTime;
        
        if (radius != 0.0F)
        {
            if (dynamicTime >= TimeLapse)
            {
                
                dynamicTime = 0;
                previousTime = currentTime;
                radius -= 1F;
                GameObject[] halfCirc = makeHalfCircle(np, radius);
                //makeSphere(halfCirc, nm, np);
            }
        }
    }

    GameObject[] makeHalfCircle(int points, float radius)
    {
        float theta;
        GameObject[] sphere = new GameObject[1000];
        for (int i = 0; i < points; i++)
        {
            theta = 3.14159274F * (float)i / (float)(points - 1);
            sphere[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere[i].transform.position = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0);
            if(shrink)
                sphere[i].transform.localScale = new Vector3(.1F, .1F, .1F);
        }
        return sphere;
    }

    void makeSphere(GameObject[] start, int meridians, int points)
    {
        for (int i = 0; i <= meridians; i++)
        {
            float phi = 2.0F * 3.14159274F * (float)i / (float)meridians;
            for (int j = 0; j < points; j++)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = new Vector3(start[j].transform.position.x,
                    (start[j].transform.position.y * Mathf.Cos(phi)) - (start[j].transform.position.z * Mathf.Sin(phi)),
                    (start[j].transform.position.y * Mathf.Sin(phi)) + (start[j].transform.position.z * Mathf.Cos(phi)));
                if(shrink)
                    sphere.transform.localScale = new Vector3(.1F, .1F, .1F);
            }
        }
    }
}