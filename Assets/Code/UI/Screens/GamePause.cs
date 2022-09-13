using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  GamePause: UIScreen 
{
	public override void OnEnable()
	{
		base.OnEnable ();
		//ConsoliAds.Instance.ShowAd (0);
		if (GameManager.Instance.interstitialAdCounter >= 6)
		{
			GameManager.Instance.interstitialAdCounter = 0;
			//ConsoliAds.Instance.ShowAd (3);

		} else {
			GameManager.Instance.interstitialAdCounter++;
			//ConsoliAds.Instance.ShowAd (0);

		}
		//ConsoliAds.Instance.firebase.LogEvent("Game Status", "Enter", "Game Pause");
	}

	public void OnNextButton()
	{
		
	}

}
