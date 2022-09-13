using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  SelectionMenu : UIScreen 
{

	[SerializeField]
	private GameObject[] selectionVehicles;
	[SerializeField]
	private GameObject watchVideoMessage;
	[SerializeField]
	private GameObject adNotAvailableDialogue;


	int totalStars = 0;

	int vehicleIndex;


	public override void OnEnable()
	{
		base.OnEnable ();
		GameManager.isVideoShown = false;
		//GameObject.Find ("Cylinder").GetComponent<SelectionVehicle> ().enabled = true;
		//ConsoliAds.Instance.firebase.LogEvent("Menu", "Enter", "Car Selection");
	}

	void Start()
	{
		//ConsoliAds.onRewardedVideoAdCompletedEvent += OnVideoCompleted; 
		
		for (int i = 0; i < 10; i++) {
			for (int j = 0; j < PlayerPrefs.GetInt(AppConstants.LEVEL_STARS + (i + 1).ToString()); j++) {
				totalStars++;
			}		
		}
		
		selectionVehicles [0].SetActive (true);

	}


	void Update()
	{
		if (GameManager.isVideoShown) {
			//GameManager.isVideoShown = false;
			UnlockCar ();
		}

		if (Input.GetKeyDown(KeyCode.Z)) {
			UnlockCar ();	
		}

		Debug.Log (vehicleIndex.ToString());
	}

	public void OnNavigateNextButton()
	{
		
		if (vehicleIndex <= 4) 
		{GameManager.Instance.buttonSound.Play ();
			
			selectionVehicles [vehicleIndex].SetActive (false);
			selectionVehicles [++vehicleIndex].SetActive (true);

			if (vehicleIndex == 1 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR2) == false ||
				vehicleIndex == 2 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR3) == false ||
			    vehicleIndex == 3 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR4) == false ||
				vehicleIndex == 4 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR5) == false ||
				vehicleIndex == 5 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR6) == false
			) 
			{
				watchVideoMessage.SetActive (true);
			} 
			else 
			{
				watchVideoMessage.SetActive (false);
			}


		}
	}

	public void OnNavigatePreviousButton()
	{
		if (vehicleIndex >= 1) 
		{
			GameManager.Instance.buttonSound.Play ();
			
			selectionVehicles [vehicleIndex].SetActive (false);
			selectionVehicles [--vehicleIndex].SetActive (true);

		if (vehicleIndex == 1 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR2) == false ||
			vehicleIndex == 2 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR3) == false ||
			vehicleIndex == 3 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR4) == false ||
			vehicleIndex == 4 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR5) == false ||
			vehicleIndex == 5 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR6) == false
			) 
			{
				watchVideoMessage.SetActive (true);
			} 
			else 
			{
				watchVideoMessage.SetActive (false);
			}
		}
	}

	public void OnPlayButton()
	{
		GameManager.Instance.buttonSound.Play ();
		
		if (vehicleIndex == 1 && PlayerPrefsX.GetBool(AppConstants.IS_LOCKED_CAR2) == true ||
			vehicleIndex == 2 && PlayerPrefsX.GetBool(AppConstants.IS_LOCKED_CAR3) == true ||
			vehicleIndex == 3 && PlayerPrefsX.GetBool(AppConstants.IS_LOCKED_CAR4) == true ||
			vehicleIndex == 4 && PlayerPrefsX.GetBool(AppConstants.IS_LOCKED_CAR5) == true ||
			vehicleIndex == 5 && PlayerPrefsX.GetBool(AppConstants.IS_LOCKED_CAR6) == true ||
			vehicleIndex == 0
			)
		{
			GameManager.Instance.selectedVehicle = vehicleIndex + 1;
			GameManager.Instance.gameStatus = GAME_STATUS.GAME_PLAY;
			GameManager.UI.Show (SCREEN_NAME.MODE_SELECTION);

		} 


	}

	int num = 1;
	public void ShowRewardedVideo()
	{
		Debug.Log ("ShowRewardedVideo");
		//if (ConsoliAds.Instance.IsAdAvailable (3)) {
		if (num % 2 == 0) {
			//ConsoliAds.Instance.ShowAd (4);
		} 
		num++;
		//ConsoliAds.Instance.ShowAd (3);


		//}
//		else {
//			adNotAvailableDialogue.SetActive (true);
//		}

		//ConsoliAds.Instance.firebase.LogEvent("Button Click", "On Click", "ShowRewardedVideo");

	}

	public void OnVideoCompleted()
	{
		GameManager.isVideoShown = true;
	}

	public void UnlockCar()
	{
		GameManager.isVideoShown = false;
		
		switch (vehicleIndex) 
		{
		case 1:
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR2, true);
			break;
		case 2:
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR3, true);
			break;
		case 3:
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR4, true);
			break;
		case 4:
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR5, true);
			break;
		case 5:
			PlayerPrefsX.SetBool (AppConstants.IS_LOCKED_CAR6, true);
			break;
			}


		if (vehicleIndex == 1 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR2) == false ||
			vehicleIndex == 2 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR3) == false ||
			vehicleIndex == 3 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR4) == false ||
			vehicleIndex == 4 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR5) == false ||
			vehicleIndex == 5 && PlayerPrefsX.GetBool (AppConstants.IS_LOCKED_CAR6) == false 
			) 
		{
			watchVideoMessage.SetActive (true);
		} else {
			watchVideoMessage.SetActive (false);
		}
	}

	public override void OnMenuButton()
	{Time.timeScale = 1;
		GameManager.Instance.buttonSound.Play ();
		Application.LoadLevel (Application.loadedLevel);
	}


	void OnApplicationFocus( bool hasFocus )
	{
		if (hasFocus) {
			Debug.Log ("hi there!");
			if (GameManager.isVideoShown) {
				//GameManager.isVideoShown = false;
				UnlockCar ();
			}
		}


	}




}
