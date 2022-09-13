using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  ModeSelection : UIScreen 
{
	
	public override void OnEnable()
	{
		base.OnEnable ();


		if (GameManager.Instance.interstitialAdCounter >= 6)
		{
			GameManager.Instance.interstitialAdCounter = 0;
			//ConsoliAds.Instance.ShowAd (3);

		} else {
			GameManager.Instance.interstitialAdCounter++;
			//ConsoliAds.Instance.ShowAd (0);

		}

		//ConsoliAds.Instance.firebase.LogEvent("Menu", "Enter", "Mode Selection");
	}


		
	public void OnHillFreeRideButton()
	{
		GameManager.Instance.buttonSound.Play ();
		GameManager.Instance.GameMode = GAME_MODE.HILL_FREE_RIDE;
		GameManager.UI.Show (SCREEN_NAME.LOADING);

	}

	public void OnGroundFreeRideButton()
	{
		GameManager.Instance.buttonSound.Play ();
		GameManager.Instance.GameMode = GAME_MODE.GROUND_FREE_RIDE;
		GameManager.UI.Show (SCREEN_NAME.LOADING);

	}

	public void OnMissionButton()
	{
		GameManager.Instance.buttonSound.Play ();
		GameManager.Instance.GameMode = GAME_MODE.LEVELS;
		GameManager.UI.Show (SCREEN_NAME.LEVEL_SELECTION);
	}



	public void OnBackButton ()
	{
		GameManager.Instance.buttonSound.Play ();
		GameManager.UI.Show (SCREEN_NAME.SELECTION_MENU);
	}


}
