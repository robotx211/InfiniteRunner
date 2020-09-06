using UnityEngine;
using System.Collections;

public class StaticObjectScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (this);
	}
}
