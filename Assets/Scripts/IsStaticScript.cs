using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IsStaticScript : MonoBehaviour {
	//sets the object to not be destroyed on scene load
	//needs to check if an instance of the object already exists, then destroy the duplicate
	void Awake () {
		GameObject[] musics = GameObject.FindGameObjectsWithTag ("music");
		if (musics.Length > 1) {
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad (this.gameObject);
	}

}
