using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private float waitTime = 0.0f;
	private float lastSpawn = 0.0f;

	public GameObject enemyStill;
	public GameObject enemyRoll;
	public GameObject enemyFly;

	void Update () {

		//works in the same way as the background object spawner, but does not keep track of the last enemy spawned, so the same enemy can be spawned twice
		if (Time.time > lastSpawn + waitTime)
		{
			switch (Random.Range(0,3))
			{
			case 0:
				{
					Instantiate(enemyStill, new Vector3 (19.77f,1.36f,0.0f), new Quaternion());
					break;
				}
			case 1:
				{
					Instantiate(enemyRoll, new Vector3 (19.77f,0.71f,0.0f), new Quaternion());
					break;
				}
			case 2:
				{
					Instantiate(enemyFly, new Vector3 (19.77f,4.2f,0.0f), new Quaternion());
					break;
				}
			default:
				{
					Debug.Log ("Invalid enemy object number");
					break;
				}
			}


			lastSpawn = Time.time;
			waitTime = Random.Range(2f, 4f);

		}


	}
}
