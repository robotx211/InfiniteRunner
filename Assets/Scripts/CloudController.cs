using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	//scale factor for size scaling of clouds and setting o scroll speed
    private float scaleFactor;

	//scrolling speed of cloud
    public float scrollSpeed;

    void Awake () {
		//scaling factor is based on cloud y position and a radom range of -2 to +2
		scaleFactor = this.transform.position.y * 0.2f + Random.Range(-0.2f, 0.2f);
        this.transform.localScale = new Vector3(scaleFactor, scaleFactor, 0.0f);
		scrollSpeed = scaleFactor;
    }

	void Update () {  
		//if off screen to left
		if (transform.position.x < -40.32f)
		{
			Destroy(this.gameObject);
		}
    }


    private void LateUpdate()
    {
		//move based on scrollSpeed and score
		transform.Translate(new Vector2(-scrollSpeed * (1.0f + ((float)HighScoresAndOptions.score/1000)), 0) * Time.deltaTime, Space.World);
    }
}
