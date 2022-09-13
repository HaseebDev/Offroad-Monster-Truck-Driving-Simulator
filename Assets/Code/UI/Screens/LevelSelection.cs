using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  LevelSelection: UIScreen 
{
	public GameObject[] locks;
	public Sprite greenSprite;
	public Sprite blueSprite;

	public override void OnEnable()
	{
		base.OnEnable ();
		//PlayerPrefs.SetInt (AppConstants.LEVEL, 10);
		for (int i = 0; i < locks.Length; i++)
		{
			locks [i].transform.Find ("Stars").GetChild(0).gameObject.SetActive(false);
			locks [i].transform.Find ("Stars").GetChild(1).gameObject.SetActive(false);
			locks [i].transform.Find ("Stars").GetChild(2).gameObject.SetActive(false);

		}

		for (int i = 0; i < locks.Length; i++)
		{

			if (i < PlayerPrefs.GetInt (AppConstants.LEVEL))
			{
				locks [i].GetComponent<Image> ().sprite = greenSprite;
				if (PlayerPrefs.GetInt(AppConstants.LEVEL_STARS + (i + 1)) == 3) 
				{
					locks [i].transform.GetChild (0).gameObject.SetActive (false);
					locks [i].transform.GetChild (1).gameObject.SetActive(true);
				} else {
					locks [i].transform.GetChild (1).gameObject.SetActive(false);
				}
			} 
			else 
			{
				locks [i].GetComponent<Image> ().sprite = blueSprite;
				locks [i].transform.GetChild (1).gameObject.SetActive(false);
				locks [i].transform.GetChild (0).gameObject.SetActive (true);
			}
				
		}

			//ConsoliAds.Instance.ShowAd (1);
//		for (int i = 1; i < PlayerPrefs.GetInt (AppConstants.LEVEL); i++) {
//			if (i < locks.Length) {
//				locks [i].transform.GetChild (0).gameObject.SetActive (false);
//				locks [i].GetComponent<Image> ().sprite = greenSprite;
//			} else {
//				locks [i].GetComponent<Image> ().sprite = blueSprite;
//			}
	//	}
//
		for (int i = 0; i < locks.Length; i++)
		{
			for (int j = 0; j < PlayerPrefs.GetInt(AppConstants.LEVEL_STARS + (i + 1).ToString()); j++) {
				locks [i].transform.Find ("Stars").GetChild (j).gameObject.SetActive (true);
			}
		}

		//ConsoliAds.Instance.firebase.LogEvent("Menu", "Enter", "Level Selection");
}

	public void OnLevelButton(int level)
	{
		Debug.Log (level.ToString());
		Debug.Log (PlayerPrefs.GetInt (AppConstants.LEVEL).ToString());
		GameManager.Instance.buttonSound.Play ();

		if (level <= PlayerPrefs.GetInt (AppConstants.LEVEL)) 
		{
		
			GameManager.Instance.currentLevel = level;
			GameManager.UI.Show (SCREEN_NAME.LOADING);
		}
	}
		

	public void OnBackButton ()
	{GameManager.Instance.buttonSound.Play ();
		
		GameManager.UI.Show (SCREEN_NAME.MODE_SELECTION);
	}


}
