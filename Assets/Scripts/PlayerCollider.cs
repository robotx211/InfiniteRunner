using UnityEngine;

/*
 * Provide the obstacles with a way of damaging the player.
 */
public class PlayerCollider : MonoBehaviour
{
	/*
	* A trigger callback to detect when the player's collider has
	* entered the obstacle's. Then simply obtain the PlayerController
	* reference can apply damage. Then remove the obstacle for feedback.
	*/
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
	
			// Obtain a reference to the Player's PlayerController
			PlayerController playerController = this.gameObject.GetComponent<PlayerController> ();

			// Register damage with player
			playerController.Damage();

			// Make this object disappear
			GameObject.Destroy(other.gameObject);

		}

	}
}
