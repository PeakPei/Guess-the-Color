using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackButton : MonoBehaviour {

	public Sprite circleRed, circleBlue;
	private const string MAIN_SCENE_NAME = "menu";

	void OnMouseDown(){
		GetComponent <SpriteRenderer> ().sprite = circleRed;
	}

	void OnMouseUp(){
		GetComponent <SpriteRenderer> ().sprite = circleBlue;
	}

	void OnMouseUpAsButton(){
		switch (gameObject.name) {
		case "back":
			Application.LoadLevel (MAIN_SCENE_NAME);
			break;
		}
	}
}
