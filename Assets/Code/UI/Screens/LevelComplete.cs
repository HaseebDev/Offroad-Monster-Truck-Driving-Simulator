using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  LevelComplete: UIScreen 
{

	public GameObject[] stars;
	public Text completionTime;

	int totalStars = 0;
	int totalScore = 0;



	public override void OnEnable()
	{
		base.OnEnable ();



		if (GameManager.Instance.currentLevel == 10)
			transform.Find ("DialogueBG").Find ("Next").gameObject.SetActive (false);
		
		for (int i = 0; i < stars.Length; i++) 
		{
			stars [i].SetActive (false);
		}

		if (GameManager.Instance.currentLevel >= PlayerPrefs.GetInt(AppConstants.LEVEL))
		{
			PlayerPrefs.SetInt (AppConstants.LEVEL, PlayerPrefs.GetInt(AppConstants.LEVEL) + 1);
		}



		for (int i = 0; i < GameManager.Instance.levelStars; i++) 
		{
			if(GameManager.Instance.levelStars > 0)
				stars [i].SetActive (true);
		}

		if (PlayerPrefs.GetInt(AppConstants.LEVEL_STARS + GameManager.Instance.currentLevel.ToString()) < GameManager.Instance.levelStars)
		{
			PlayerPrefs.SetInt (AppConstants.LEVEL_STARS + GameManager.Instance.currentLevel.ToString (), GameManager.Instance.levelStars);
		}

		if (PlayerPrefs.GetInt(AppConstants.LEVEL_REMAINING_TIME + GameManager.Instance.currentLevel.ToString()) < GameManager.Instance.levelRemainingTime)
		{
			PlayerPrefs.SetInt (AppConstants.LEVEL_REMAINING_TIME + GameManager.Instance.currentLevel.ToString (), GameManager.Instance.levelRemainingTime);
		}

		System.TimeSpan time = System.TimeSpan.FromSeconds(GameObject.FindObjectOfType<GameController>().levels[GameManager.Instance.currentLevel - 1].LevelTime - GameManager.TIMER.RemainingTime);
		string str = time.ToString();
		completionTime.text = str.Substring(3,5);

		for (int i = 1; i <= PlayerPrefs.GetInt(AppConstants.LEVEL); i++) 
		{
			for (int j = 1; j <= PlayerPrefs.GetInt(AppConstants.LEVEL_STARS + i); j++) 
			{
				totalStars++;
			}
		}

		for (int i = 1; i <= PlayerPrefs.GetInt(AppConstants.LEVEL); i++) 
		{
			totalScore += PlayerPrefs.GetInt (AppConstants.LEVEL_STARS + i.ToString ()) * PlayerPrefs.GetInt (AppConstants.LEVEL_REMAINING_TIME + i.ToString ());
		}

		PlayerPrefs.SetInt (AppConstants.TOTAL_STARS, totalStars);
		PlayerPrefs.SetInt (AppConstants.SCORES, totalScore);

		//Debug.Log (PlayerPrefs.GetInt (AppConstants.SCORES));
		if (GameManager.Instance.currentLevel == 3) {
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR4, true);

		}

		if (GameManager.Instance.currentLevel == 5) {
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR5, true);

		}

		if (GameManager.Instance.currentLevel == 7) {
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR6, true);

		}
		//ConsoliAds.Instance.ShowAd (2);
		if (GameManager.Instance.interstitialAdCounter >= 6)
		{
			GameManager.Instance.interstitialAdCounter = 0;
			//ConsoliAds.Instance.ShowAd (3);

		} else {
			GameManager.Instance.interstitialAdCounter++;
			//ConsoliAds.Instance.ShowAd (2);

		}
		//ConsoliAds.Instance.firebase.LogEvent("Game Status", "Success", "Level: " + GameManager.Instance.currentLevel.ToString() + "Completed");

	}	

	public void OnNextButton()
	{
		GameManager.Instance.buttonSound.Play ();
		
		GameManager.Instance.currentLevel++;
		GameManager.Instance.gameStatus = GAME_STATUS.GAME_PLAY;
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}

}
