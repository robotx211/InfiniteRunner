using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresAndOptions : MonoBehaviour {

	//sprites of each hat and an array of the sprites or hats (hat0 is null, as it represents no hat)
	//only assigned in Game scene, as only used in Game scene
	public Sprite[] hats;

	public Sprite hat0 = null;
	public Sprite hat1;
	public Sprite hat2;
	public Sprite hat3;
	public Sprite hat4;
	public Sprite hat5;
	public Sprite hat6;
	public Sprite hat7;
	public Sprite hat8;
	public Sprite hat9;
	public Sprite hat10;

	//static int to store the currently equiped hat
	public static int currentHat = 0;
	//public int showCurrentHat = currentHat;

	//array of booleans to show which hats have been unlocked
	private bool[] hatUnlocks;
	//int to show how many hats have been unlocked (etc. 5 means the first 5 hats (+ hat0) can be used)
	private int numHatsUnlocked = 0;

	//static int to store the current score of the player
	public static int score;

	//game object with the player hat sprite attached, starts off will hat0 (null) as a sprite
	public GameObject playerHat;

	//variables related to hat unlock notifications
	//game object which holds notification text and image
	public GameObject notification;
	//wait time is the amount of time the notification is shown, exit time is used to store the time at which to hide the notification
	private float waitTime = 1.0f;
	private float exitTime;
	//boolean used to check when a hat has been unlocked
	private bool hatUnlocked = false;


	//game objects that store the main menu and options UI elements
	public GameObject MainMenu;
	public GameObject Options;

	//static float used to set the volume of the music
	private static float musicVol = 1.0f;
	//audiosource of the music to be played
	private AudioSource music;

	//UI slider used to set the music volume 
	public Slider volSlider;


	void Start () {
		
		//checks if number of hats unlocked is in playerPrefs, if not create it and set to 0
		if (PlayerPrefs.HasKey ("numHatUnlock") == false) {
			Debug.Log ("No Pref Exists, creating one");
			PlayerPrefs.SetInt ("numHatUnlock", 0);
		} else {
			Debug.Log ("Pref Exists, hats unlocked = " + PlayerPrefs.GetInt ("numHatUnlock"));
		}

		//load number of hats unlocked from playerPrefs
		numHatsUnlocked = PlayerPrefs.GetInt ("numHatUnlock");

		//finds audio source for music and sets it's volume
		music = GameObject.Find ("random silly chip song (1)").GetComponent<AudioSource> ();
		music.volume = musicVol;

		//creates array for hatunlocks and fill it based on nuber of hats unlocked (array is 11 long, as hat0 is included)
		hatUnlocks = new bool[11];
		for (int j = 0; j < 11; j++) {
			if (j <= numHatsUnlocked) {
				hatUnlocks [j] = true;
			} else {
				hatUnlocks [j] = false;
			}
		}

		//if current scene is the menu, set the options to be hidden
		if (SceneManager.GetActiveScene ().name == "Menu") {
			MainMenu.SetActive (true);
			Options.SetActive (false);
		}

		//if current scene is the game, put all hat sprites into the hats array and set the playerHat sprite renderer to load the selected hat
		if (SceneManager.GetActiveScene ().name == "Game") {
			hats = new Sprite[11];
			waitTime = 3.0f;

			hats [0] = hat0;
			hats [1] = hat1;
			hats [2] = hat2;
			hats [3] = hat3;
			hats [4] = hat4;
			hats [5] = hat5;
			hats [6] = hat6;
			hats [7] = hat7;
			hats [8] = hat8;
			hats [9] = hat9;
			hats [10] = hat10;

			playerHat.GetComponent<SpriteRenderer>().sprite = hats[currentHat];
		}
	}

	//sets the volume of the music to be the value of the volume slider
	public void changeVolume (float _volume)
	{
		musicVol = _volume;
		music.volume = musicVol;
	}

	//function to increment score, check if a hat unlock is necessary, and if a hat is unlocked, show notification for set amount of time
	public void scoreUp()
	{
		score++;

		//if score > unlockScore and hat is not yet unlocked, then unlock and prompt notificatio
		if (score > 10 && hatUnlocks[1] == false) {
			hatUnlocks [1] = true;
			Debug.Log ("Hat1Unlock");
			numHatsUnlocked = 1;
			hatUnlocked = true;
			//gibus
		}
		if (score > 20 && hatUnlocks[2] == false) {
			hatUnlocks [2] = true;
			//bobble
			Debug.Log ("Hat2Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 2;
		}
		if (score > 30 && hatUnlocks[3] == false) {
			hatUnlocks [3] = true;
			//ushanka
			Debug.Log ("Hat3Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 3;
		}
		if (score > 40 && hatUnlocks[4] == false) {
			hatUnlocks [4] = true;
			//party
			Debug.Log ("Hat4Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 4;
		}
		if (score > 50 && hatUnlocks[5] == false) {
			hatUnlocks [5] = true;
			//penguin
			Debug.Log ("Hat5Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 5;
		}
		if (score > 60 && hatUnlocks[6] == false) {
			hatUnlocks [6] = true;
			//top
			Debug.Log ("Hat6Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 6;
		}
		if (score > 88 && hatUnlocks[7] == false) {
			hatUnlocks [7] = true;
			//B2TF
			Debug.Log ("Hat7Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 7;
		}
		if (score > 100 && hatUnlocks[8] == false) {
			hatUnlocks [8] = true;
			//afro
			Debug.Log ("Hat8Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 8;
		}
		if (score > 200 && hatUnlocks[9] == false) {
			hatUnlocks [9] = true;
			//dinosaur
			Debug.Log ("Hat9Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 9;
		}
		if (score > 999 && hatUnlocks[10] == false) {
			hatUnlocks [10] = true;
			//crown
			Debug.Log ("Hat10Unlock");
			hatUnlocked = true;
			numHatsUnlocked = 10;
		}

		//set playerPref of hat unlocks to numer unlocked
		PlayerPrefs.SetInt ("numHatUnlock", numHatsUnlocked);

		//if notification should be called, set exit time = currentTime + waitTime
		if (hatUnlocked == true) {
			exitTime = Time.time + waitTime;
			hatUnlocked = false;
		}

		//if notification has been set to call, sets hat to show and display notification. When it is over, hit notification, 
		if (Time.time < exitTime) {
			notification.GetComponentInChildren<Image> ().sprite = hats [numHatsUnlocked];
			notification.SetActive (true);
		} else {
			notification.SetActive (false);

		}

	}

	//function to block choices of hats and set initial volume slider value
	public void BlockUnlocks()
	{
		//gets all hat buttons from scene
		GameObject[] hatButtons = GameObject.FindGameObjectsWithTag ("HatButton");

		Image[] images;
		Color temp;

		//steps through each button, if unlocked (as shown is hatUnlocks[]) set to full colour, else grey out and lower opacity (of both button and image)
		for (int i = 0; i < 11; i++) {
			images = hatButtons [i].GetComponentsInChildren<Image> ();
			if (hatUnlocks[i] == true) {
				hatButtons[i].GetComponent<Button>().interactable = true;

				temp = images[1].color;
				temp.a = 1.0f;
				images[1].color = temp;
			}
			else {
				//button non-interactable is greyed out and lowers opacity
				hatButtons[i].GetComponent<Button>().interactable = false;

				//lowers sets opacity of hat image to 0.4
				temp = images[1].color;
				temp.a = 0.4f;
				images[1].color = temp;
			}

			//set volume slider to preset volume
			volSlider.value = musicVol;


		}
	}

	//function to set the selected hat when button is clicked
	public void SetHat(int _hatID)
	{
		currentHat = _hatID;
	}

	//function to reset score and hat unlocks
	public void ResetHatsAndScore()
	{
		score = 0;
		numHatsUnlocked = 0; 
		PlayerPrefs.SetInt ("numHatUnlock", numHatsUnlocked);
		currentHat = 0;

		for (int j = 0; j < 11; j++) {
			if (j <= numHatsUnlocked) {
				hatUnlocks [j] = true;
			} else {
				hatUnlocks [j] = false;
			}
		}

		BlockUnlocks ();

	}


}
