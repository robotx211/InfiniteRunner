using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	//floats to determine when an object can spawn
    private float waitTime = 0.0f;
    private float lastSpawn = 0.0f;

	//random postion of cloud, used in y and z (for depth)
	private float randomPosition;

    public GameObject cloud;

	void Update () {

        if (Time.time > lastSpawn + waitTime)
        {
			randomPosition = Random.Range (-4.5f, 5.0f);
			//spawns clouds at random heights between sea and top of screen
			Instantiate(cloud, this.transform.position + new Vector3(0.0f, randomPosition, -randomPosition), new Quaternion());
            lastSpawn = Time.time;
            waitTime = Random.Range(1f, 5f);

			//could set up system to make sure clouds dont spawn too close to each other with same speed
        }


	}
}
