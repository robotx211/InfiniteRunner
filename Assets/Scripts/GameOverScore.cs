using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {
	//dislays the score in the game over scene, and resets it, so that the background objects move at their base speed
	//the score is a static int in HighScoreAndOptions
	public Text score;

	// Use this for initialization
	void Start () {
		score.text = HighScoresAndOptions.score.ToString();
		HighScoresAndOptions.score = 0;
	}

}
