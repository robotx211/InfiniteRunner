using UnityEngine;
using UnityEngine.UI;

/*
 * On screen HUD to display current health.
 */
public class PlayerHud : MonoBehaviour
{
  private PlayerController playerController;

	//holds the UI images of heart so they can be disabled with health change
	public Image heart1;
	public Image halfHeart1;
	public Image heart2;
	public Image halfHeart2;
	public Image heart3;
	public Image halfHeart3;

	//holds the score text so the score can be displayed
	public Text score;

	/*
	* Load and store the heart images and cache the PlayerController
	* component for later.
	*/
	private void Start()
	{
		playerController = GetComponent<PlayerController> ();
	}
	/*
	* Using the current health from the PlayerController, display the
	* correct number of hearts and half hearts.
	*/
	private void Update()
	{
		//every update call, update health and score
		checkHealth ();
		checkScore ();

	}

	void checkHealth()
	{
		//if health < 1, disable 1st half heart
		if (playerController.GetHealth () < 1) {
			halfHeart1.enabled = false;
		}
		//if health < 2, disable 1st full heart etc.
		if (playerController.GetHealth () < 2) {
			heart1.enabled = false;
		}
		if (playerController.GetHealth () < 3) {
			halfHeart2.enabled = false;
		}
		if (playerController.GetHealth () < 4) {
			heart2.enabled = false;
		}
		if (playerController.GetHealth () < 5) {
			halfHeart3.enabled = false;
		}
		if (playerController.GetHealth () < 6) {
			heart3.enabled = false;
		}
	}

	void checkScore()
	{
		score.text = HighScoresAndOptions.score.ToString();
	}


}
			

