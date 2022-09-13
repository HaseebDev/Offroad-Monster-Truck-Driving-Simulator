using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPreferences : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefsX.GetBool(AppConstants.IS_FIRST_TIME) == false) 
		{
			PlayerPrefsX.SetBool (AppConstants.IS_FIRST_TIME, true);

			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR2, true);
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR3, true);
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR4, false);
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR5, false);
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR6, false);


			PlayerPrefs.SetInt (AppConstants.INTERSTITIAL_AD, 0);

			PlayerPrefs.SetInt (AppConstants.LEVEL, 1);
			PlayerPrefs.SetInt (AppConstants.SCORES, 0);
			PlayerPrefs.SetInt (AppConstants.TOTAL_STARS, 0);


			for (int i = 1; i <= 10; i++) 
			{
			
				PlayerPrefs.SetInt (AppConstants.LEVEL_STARS + i.ToString(), 0);
				PlayerPrefs.SetInt (AppConstants.LEVEL_REMAINING_TIME + i.ToString(), 0);

			}

			Debug.Log ("Init Prefs");
		}
	}
	

}
