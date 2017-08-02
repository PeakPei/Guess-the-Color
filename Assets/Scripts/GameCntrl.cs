using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class GameCntrl : MonoBehaviour {

	public GameObject panelLost;

	public GameObject colBlock;
	public Vector3 [] positions;
	private GameObject block;
	private GameObject [] blocks = new GameObject[4];

	private int rand, count;
	private float rCol, gCol, bCol;
	public Text score;
	private static Color aColor;

	/* for advertisement
	private static int loseCounter = 0;
	private bool loadedForAds;
	*/

	[HideInInspector]
	public bool next, lose;

	void Start () {
		/* for advertisement
		if (Advertisement.isSupported) {
			Advertisement.Initialize ("97412", false);
		} else {
			Debug.Log ("Platform doesn't supports advertisements");
		}
		*/
		count = 0;
		next = false;
		lose = false;
		rand = Random.Range (0, positions.Length);
		for (int i = 0; i < positions.Length; i++) {
			blocks [i] = Instantiate (colBlock, positions[i], Quaternion.identity) as GameObject;
			if (rand == i)
				block = blocks [i];
		}
		block.GetComponent <RandCol> ().right = true;
	}

	void Update () {
		if (lose  /* && !loadedForAds  -   for advertisement  */)
			playerLose ();
		if (next && !lose)
			nextColors ();
	}

	void nextColors () {
		if (PlayerPrefs.GetString ("Music") == "yes")
			GetComponent<AudioSource> ().Play ();
		
		count++;
		score.text = count.ToString ();
		aColor = new Vector4 (Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), Random.Range (0.1f, 1f), 1);
		GetComponent <Renderer> ().material.color = aColor;
		next = false;

		if (count < 3) {
			rCol = 0.2f;
			gCol = 0.2f;
			bCol = 0.2f;
		} else if (count >= 3 && count < 5) {
			rCol = 0.1f;
			gCol = 0.1f;
			bCol = 0f;
		} else if (count >= 5) {
			rCol = 0f;
			gCol = 0f;
			bCol = 0.05f;
		}

		// New colors for blocks
		rand = Random.Range (0, positions.Length);
		for (int i = 0; i < positions.Length; i++) {
			if (i == rand)
				blocks [i].GetComponent <Renderer> ().material.color = aColor;
			else {
				float r = aColor.r + Random.Range (0.1f, rCol) > 1f ? 1f : aColor.r + Random.Range (0.1f, rCol);
				float g = aColor.g + Random.Range (0.1f, gCol) > 1f ? 1f : aColor.g - Random.Range (0.1f, gCol);
				float b = aColor.b + Random.Range (0.1f, bCol) > 1f ? 1f : aColor.b + Random.Range (0.1f, bCol);
				blocks [i].GetComponent <Renderer> ().material.color = new Vector4 (r, g, b, aColor.a);
			}
		}
	}

	void playerLose () {
		/* for advertisement
		if (Advertisement.IsReady() && loseCounter % 5 == 0) {
			Advertisement.Show();
			loadedForAds = true;
		}     
		*/
		if (PlayerPrefs.GetInt ("Score") < count)
			PlayerPrefs.SetInt ("Score", count);
		panelLost.SetActive (true);
		if (PlayerPrefs.GetString ("Music") == "no")
			panelLost.GetComponent<AudioSource> ().mute = true;
	}
	/* for advertisement
	public void incrementLoseCounter(){
		loseCounter++;
	}
	*/
}