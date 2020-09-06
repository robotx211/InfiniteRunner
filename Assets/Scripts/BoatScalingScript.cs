using UnityEngine;
using System.Collections;

public class BoatScalingScript : MonoBehaviour {

	void Start () {
		//scales based on yPos - 5.5 = -0.625(scale - 1), derived using y-y1 = m(x-x1) from y1=5.5, scale1=1, y2=3, scale2=5
		this.transform.localScale = new Vector3 ( ((-1.0f * this.transform.position.y) / 0.625f) + 9.8f, ((-1.0f * this.transform.position.y) / 0.625f) + 9.8f, 1.0f);
	}
}
