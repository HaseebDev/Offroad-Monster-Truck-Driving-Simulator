using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class  GameOver: UIScreen 
{
	public override void OnEnable()
	{
		base.OnEnable ();
		//ConsoliAds.Instance.ShowAd (1);
		if (GameManager.Instance.interstitialAdCounter >= 6)
		{
			GameManager.Instance.interstitialAdCounter = 0;
			//ConsoliAds.Instance.ShowAd (3);

		} else {
			GameManager.Instance.interstitialAdCounter++;
			//ConsoliAds.Instance.ShowAd (1);

		}
		//ConsoliAds.Instance.firebase.LogEvent("Game Status", "Failure", "Level: " + GameManager.Instance.currentLevel.ToString() + "Failed");

	}

	public void OnNextButton()
	{
		
	}

}
