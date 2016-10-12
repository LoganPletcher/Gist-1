using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    float currentTime, previousTime = 0, deltaTime;
    float change = 0;
    public GameObject cube;
    public int clones = 0, speed = 1;
    bool up = true;
	// Use this for initialization
	void Start () {
        change = 1;
        for (int i = 0; i < clones; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10.0F,10.0F), Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));
            Instantiate(cube, position, cube.transform.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
        currentTime = Time.time;
        deltaTime = currentTime - previousTime;
        if (up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * deltaTime);
            if (transform.position.z >= 10)
                up = false;
        }
        else if (!up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * deltaTime);
            if (transform.position.z <= -10)
                up = true;
        }
        previousTime = currentTime;
	}
}
