using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

	//script to scroll background objects
	public float scrollSpeed;

	void Update () {
		//if off screen to left
		if (transform.position.x < -40.32f)
		{
			Destroy(this.gameObject);
		}
	}

	private void LateUpdate()
	{
		transform.Translate(new Vector2(-scrollSpeed * (1.0f + ((float)HighScoresAndOptions.score/1000) ), 0) * Time.deltaTime, Space.World);
	}
}
