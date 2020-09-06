using UnityEngine;
using System.Collections;

public class EnemyFlyingScript : MonoBehaviour {
	//script to make the flying enemy bob up and down, by making it's y position a cos of it's x position

	void Update () {
		this.transform.position = new Vector3 (this.transform.position.x, 0.2f * Mathf.Cos (this.transform.position.x) + 4.2f, 0);
	}
}
