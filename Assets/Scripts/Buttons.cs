using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	public GameObject musicOnPic, musicOffPic;
	public Sprite circleRed, circleBlue;
	private const string RATING_URL = "http://google.com";
	private const string FACEBOOK_URL = "http://facebook.com";
	private const string GAME_SCENE_NAME = "game";
	private const string MENU_SCENE_NAME = "menu";
	private const string HOW_TO_PLAY_SCENE_NAME = "howToPlay";

	void Start(){
		if(gameObject.name == "turn_music_on_off")
			if (PlayerPrefs.GetString ("Music") == "no") {
				musicOffPic.SetActive (true);
				musicOnPic.SetActive (false);
			}
	}

	void OnMouseDown(){
		GetComponent <SpriteRenderer> ().sprite = circleRed;
	}

	void OnMouseUp(){
		GetComponent <SpriteRenderer> ().sprite = circleBlue;
	}

	void OnMouseUpAsButton(){
		if (PlayerPrefs.GetString ("Music") == "yes")
			GameObject.Find ("Click Audio").GetComponent <AudioSource> ().Play ();
		switch (gameObject.name) {
		case "play_game":
			Application.LoadLevel (GAME_SCENE_NAME);
			break;
		case "app_rating_play_market":
			Application.OpenURL (RATING_URL);
			break;
		case "buy_no_ads":
			
			break;
		case "restore_purchase":
			
			break;
		case "turn_music_on_off":
			if (PlayerPrefs.GetString ("Music") == "yes") {
				PlayerPrefs.SetString ("Music", "no");
				musicOffPic.SetActive (true);
				musicOnPic.SetActive (false);
			} else {
				PlayerPrefs.SetString ("Music", "yes");
				musicOffPic.SetActive (false);
				musicOnPic.SetActive (true);
			}
			break;
		case "how_to_play":
			Application.LoadLevel (HOW_TO_PLAY_SCENE_NAME);
			break;
		case "replay":
			Application.LoadLevel (GAME_SCENE_NAME);
			break;
		case "home":
			Application.LoadLevel (MENU_SCENE_NAME);
			break;
		case "facebook":
			Application.OpenURL (FACEBOOK_URL);
			break;
		case "close":
			Application.LoadLevel (MENU_SCENE_NAME);
			break;
		}
	}
}
