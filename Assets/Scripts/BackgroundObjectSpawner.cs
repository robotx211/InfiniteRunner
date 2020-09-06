using UnityEngine;
using System.Collections;

public class BackgroundObjectSpawner : MonoBehaviour {

	//floats to determin when an object can spawn
	private float waitTime = 0.0f;
	private float lastSpawn = 0.0f;

	//keeps track of which object was spawned and is spawning, to stop the same object spawning twice in a row
	//(becasue not all objects have been set, this means there will be at least 1 spawning interval between the same object being spawned
	private int lastObject = 6;
	private int thisObject;

	//stores prefabs of background objects to spawn
	public GameObject lightHouse;
	public GameObject boat;

	void Update () {

		//if enough time has passed since the last spawn (set by waitTime)
		if (Time.time > lastSpawn + waitTime)
		{
			//random int between 0 and 5 until it is different to the last on randomed
			do {
				thisObject = Random.Range (0, 6); //0 -> 5
			} while(thisObject == lastObject);

			//cases 2 to 5 were left empty, so other objects could be added. This means there is (on average) a longer wait time between background objects spawning
			switch (thisObject)
			{
			case 0:
				{
					Instantiate(lightHouse, new Vector3 (19.77f,7.81f,0.0f), new Quaternion());
					//Debug.Log (0);
					lastObject = 0;
					break;
				}
			case 1:
				{
					//y pos is randomed, to let boats spawn a different heights in the sea
					Instantiate(boat, new Vector3 (19.77f,Random.Range(3.0f,5.5f),0.0f), new Quaternion());
					//Debug.Log (1);
					lastObject = 1;
					break;
				}
			case 2:
				{
					//Instantiate(lightHouse, new Vector3 (19.77f,7.81f,0.0f), new Quaternion());
					//Debug.Log (2);
					lastObject = 2;
					break;
				}
			case 3:
				{
					//Instantiate(lightHouse, new Vector3 (19.77f,7.81f,0.0f), new Quaternion());
					//Debug.Log (3);
					lastObject = 3;
					break;
				}
			case 4:
				{
					//Instantiate(lightHouse, new Vector3 (19.77f,7.81f,0.0f), new Quaternion());
					//Debug.Log (4);
					lastObject = 4;
					break;
				}
			case 5:
				{
					//Instantiate(lightHouse, new Vector3 (19.77f,7.81f,0.0f), new Quaternion());
					//Debug.Log (5);
					lastObject = 5;
					break;
				}

			default:
				{
					Debug.Log ("Invalid background object number: " + thisObject);
					lastObject = 6;
					break;
				}
			}

			//reset timings, wait time is set between 15 and 20, to make spawning more random
			lastSpawn = Time.time;
			waitTime = Random.Range(15f, 20f);

		}


	}
}
