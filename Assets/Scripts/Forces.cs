using UnityEngine;
using System.Collections;

public class Forces : MonoBehaviour {
    public GameObject sphere;
    public Vector3 desiredVelocity, Velocity;
    public Vector3 currentVelocity, steeringVector;
    public float mass = 1, speed = .2F;
	// Use this for initialization
	void Start () {
        currentVelocity = transform.position.normalized;
	}
	// Update is called once per frame
	void Update () {
        desiredVelocity = (sphere.transform.position - transform.position);
        steeringVector = CalcSteering(currentVelocity, desiredVelocity);
        Velocity = makeVelocity(Velocity, steeringVector);
        addForce(Velocity);
        steeringVector = CalcSteering(currentVelocity, desiredVelocity);
	}
    Vector3 makeVelocity(Vector3 V, Vector3 sV)
    {
        if (V.magnitude > 5)
            V = V.normalized;
        return V + sV; 
    }
    Vector3 CalcSteering(Vector3 cV, Vector3 dV)
    {
        Vector3 sV = (dV - cV) / mass;

        return sV;
    }
    void addForce(Vector3 nV)
    {
        transform.position += nV * speed;
    }
}
