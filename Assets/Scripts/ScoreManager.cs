using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	//sets time between scoreUp calls
	public float waitTime;
	public float lastTime;

	public GameObject menuManager;

	void Start () {
		waitTime = 1f;
		lastTime = 0.0f;
	}
	//every second, increase the score by 1
	void Update () {
		if (Time.time >= lastTime + waitTime) {
			this.GetComponent<HighScoresAndOptions>().scoreUp();
			lastTime = Time.time;
		}
	}
}
