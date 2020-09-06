using UnityEngine;

/*
 * Attached to the section so that everything will scroll sideways.
 * The player does not move in this game, the environment does.
 */
public class SectionScroller : MonoBehaviour
{
	public float scrollSpeed;

	/*
	* Use the Transform component attached to the section game object and
	* translate it based on delta time.
	*/

	private void Update()
	{
		if (transform.position.x < -40.32f) {
			transform.Translate (40.32f * 2, 0f, 0f);
		}
	}


	private void LateUpdate()
	{
		transform.Translate(new Vector2(-scrollSpeed * (1.0f + ((float)HighScoresAndOptions.score/1000)), 0) * Time.deltaTime, Space.World);
	}
}
