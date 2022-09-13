using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class  LoadingScreen : UIScreen
{
	public Image loadingBar;
	public Text loadingPercentageText;
	public AsyncOperation async;

		IEnumerator Start() {
			async = Application.LoadLevelAsync("Game");
			yield return async;
			Debug.Log("Loading complete");
			GameManager.Instance.gameStatus = GAME_STATUS.GAME_PLAY;
			Application.LoadLevel (Application.loadedLevel + 1);
		}

	public override void OnEnable()
	{
		base.OnEnable ();
		GameManager.Instance.gameStatus = GAME_STATUS.GAME_PLAY;
	}

	void Update()
	{
			Debug.Log (async.progress.ToString ());
			loadingPercentageText.text = Mathf.RoundToInt((async.progress + 0.1f) * 100 ).ToString () + " %";
			loadingBar.fillAmount = async.progress;

	}
}
