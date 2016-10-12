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
        //if (change == 1)
        //{
        //    this.transform.position *= Time.time;
        //    change = 2;
        //}
        //if (change == 2)
        //{
        //    this.transform.position = new Vector3(transform.position.x + Time.time,
        //        transform.position.y + Time.time, transform.position.z + Time.time);
        //    change = 3;
        //}
        //if (change == 3)
        //{
        //    this.transform.position /= Time.time;
        //    change = 1;
        //}
        currentTime = Time.time;
        deltaTime = currentTime - previousTime;
        if (up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * deltaTime, transform.position.z);
            if (transform.position.y >= 10)
                up = false;
        }
        else if (!up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * deltaTime, transform.position.z);
            if (transform.position.y <= -10)
                up = true;
        }
        previousTime = currentTime;
	}
}
