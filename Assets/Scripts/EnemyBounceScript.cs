using UnityEngine;
using System.Collections;

public class EnemyBounceScript : MonoBehaviour {
	//script to make boucing enemy bounce (not used in final build, as was not balanced)

	public float jumpForce;

	void FixedUpdate ()
	{
		//if y below 0.9, give vertical force to make 'bounce'
		if (this.transform.position.y <= 0.9)
		{
			this.GetComponent<Rigidbody2D> ().AddForce (  new Vector2(0, jumpForce)  );
		}
	}
}
