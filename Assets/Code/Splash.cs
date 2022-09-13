using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

	public Image loadingBar;
	public Text loadingPercentageText;


	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (3.5f);
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	// Update is called once per frame
	void Update () {
		if (loadingBar.fillAmount > 1) {
			return;
		} else {
			loadingPercentageText.text = Mathf.RoundToInt((loadingBar.fillAmount * 100 )).ToString() + " %";
			loadingBar.fillAmount += Time.deltaTime * 0.3f;
		}
	}
}
