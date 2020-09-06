using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Behaviour to handle keyboard input and also store the player's
 * current health.
 */
public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rigidbody2d;
	private int health;

	//animator for the player
	public Animator dinoAnimator;

	/*
	* Apply initial health and also store the Rigidbody2D reference for
	* future because GetComponent<T> is relatively expensive.
	*/
	private void Start()
	{
		dinoAnimator = GetComponent<Animator> ();

		health = 6;
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	/*
	* Remove one health unit from player and if health becomes 0, change
	* scene to the end game scene.
	*/
	public void Damage()
	{
		health -= 1;

		if(health < 1)
		{
			//Application.LoadLevel("EndGame");
			SceneManager.LoadScene ("EndGame");

		}
	}

	/*
	* Accessor for health variable, used by he HUD to display health.
	*/
	public int GetHealth()
	{
		return health;
	}

	private void Update()
	{
		//if up press (or held) and not already jumping or ducking, add jump force and move to jumping animation
		if (Input.GetAxisRaw("Vertical") == 1) {
			if (dinoAnimator.GetBool ("IsJump") == false && dinoAnimator.GetBool ("IsDrop") == false) {
				dinoAnimator.SetBool ("IsJump", true);
				rigidbody2d.AddForce (new Vector2 (0, 600));
			}
		} 

		//if down pressed and held and not already ducking or jumping, move to ducking animation
		if (Input.GetAxisRaw("Vertical") == -1) {
			if (dinoAnimator.GetBool ("IsDrop") == false && dinoAnimator.GetBool ("IsJump") == false) {
				dinoAnimator.SetBool ("IsDrop", true);
			}
		} 
		//if not holding down and is ducking, move to moving animation
		else if (Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == 0){
			if (dinoAnimator.GetBool ("IsDrop") == true) {
				dinoAnimator.SetBool ("IsDrop", false);

			}
		}
			

	}

	/*
	* If the player has collided with the ground, set the canJump flag so that
	* the player can trigger another jump.
	*/
	private void OnCollisionEnter2D (Collision2D other)
	{
		if (dinoAnimator.GetBool ("IsJump") == true) {
			dinoAnimator.SetBool ("IsJump", false);
		}
	}
}
