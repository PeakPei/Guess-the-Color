using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MaxScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent <Text>().text = PlayerPrefs.GetInt ("Score").ToString ();
	}
}
