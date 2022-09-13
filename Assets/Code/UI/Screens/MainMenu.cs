using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UIScreen
{

	[SerializeField]
	private GameObject settingsObj;

	void Start()
	{
//		PlayerPrefs.SetInt (AppConstants.LEVEL, 7);
//		Debug.Log (PlayerPrefs.GetInt(AppConstants.LEVEL));
	}
		

	public override void OnEnable()
	{
		base.OnEnable ();
		//ConsoliAds.Instance.firebase.LogEvent("Menu", "Enter", "Main Menu");
	}

	public void OnPlayButton()
	{GameManager.Instance.buttonSound.Play ();
		
		GameManager.UI.Show (SCREEN_NAME.SELECTION_MENU);

	}

	public void OnMoreGamesbutton()
	{
		GameManager.Instance.buttonSound.Play ();
        Application.OpenURL ("https://play.google.com/store/apps/developer?id=ARsoch");

    }

    public void OnRateUsButton()
	{
		GameManager.Instance.buttonSound.Play ();
		Application.OpenURL ("market://details?id=" + Application.identifier);


    }

	public void OnExitButton()
	{GameManager.Instance.buttonSound.Play ();
		
		Application.Quit ();
	}

	public void OnSettingsButton()
	{GameManager.Instance.buttonSound.Play ();
		
		//GameManager.UI.Show (SCREEN_NAME.SETTINGS);

		if (!settingsObj.activeInHierarchy) {
			settingsObj.SetActive (true);
		} else {
			settingsObj.SetActive (false);
		}
	}




}
