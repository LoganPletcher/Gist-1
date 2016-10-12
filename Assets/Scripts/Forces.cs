using UnityEngine;
using System.Collections;

public class Forces : MonoBehaviour
{
    public GameObject sphere;
    public Vector3 desiredVelocity, Velocity, steeringVector;
    public float mass = 1, speed = .2F, sM = 1, aM = 1, radius = 3, ArrStr = 0;
    // Use this for initialization
    void Start()
    {
        Velocity = transform.position.normalized;
    }
    // Update is called once per frame
    void Update()
    {
        desiredVelocity = sphere.transform.position - transform.position;
        Vector3 seeking = Seeking(desiredVelocity, Velocity, sM);
        //Vector3 avoid = Avoid(desiredVelocity, Velocity, aM);
        if (desiredVelocity.magnitude <= radius)
            ArrStr = (desiredVelocity.magnitude) / radius;
        else
            ArrStr = 0;
        //Vector3 arrivalVelocity = (transform.position - sphere.transform.position) * ArrStr;
        steeringVector = seeking/* + avoid + arrivalVelocity*/;
        Velocity += steeringVector;
        transform.position += (Velocity / mass) * speed;
    }
    Vector3 makeVelocity(Vector3 V, Vector3 sV)
    {
        if (V.magnitude > 5)
            V = V.normalized;
        return V + sV;
    }

    Vector3 Seeking(Vector3 dV, Vector3 V, float seekMag)
    {
        Vector3 seeking = (dV - V) * seekMag;
        return seeking;
    }
    Vector3 Avoid(Vector3 dV, Vector3 V, float avMag)
    {
        Vector3 avoid = -((dV - V) * avMag);
        return avoid;
    }
}