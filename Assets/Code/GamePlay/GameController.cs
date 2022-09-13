using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour 
{
	public Level[] levels;
	public GameObject[] vehicles;

	public Transform freeRidePointGround;
	public Transform freerRidePointHill;

	void Awake()
	{
	 	
	}

	// Use this for initialization
	void Start () 
	{
		GameManager.Instance.levelStars = 0;
		GameManager.Instance.levelRemainingTime = 0;
		GameManager.UI.Show (SCREEN_NAME.GAME_PLAY);
		vehicles [GameManager.Instance.selectedVehicle - 1].SetActive (true);
		//GameObject.FindObjectOfType<SmoothFollowCamera> ().target = GameManager.player.FollowdObject;

		if (GameManager.Instance.gameStatus == GAME_STATUS.GAME_PLAY && GameManager.Instance.GameMode == GAME_MODE.GROUND_FREE_RIDE) 
		{
			GameManager.player.transform.position = freeRidePointGround.position;
			GameManager.player.transform.rotation = freeRidePointGround.rotation;
			GameManager.player.Arrow.gameObject.SetActive (false);
			//ConsoliAds.Instance.firebase.LogEvent("Game Play", "Start", "Ground Free Ride Mode");
		}
		else if (GameManager.Instance.gameStatus == GAME_STATUS.GAME_PLAY && GameManager.Instance.GameMode == GAME_MODE.HILL_FREE_RIDE) 
		{
			GameManager.player.transform.position = freerRidePointHill.position;
			GameManager.player.transform.rotation = freerRidePointHill.rotation;
			GameManager.player.Arrow.gameObject.SetActive (false);
			//ConsoliAds.Instance.firebase.LogEvent("Game Play", "Start", "Hill Free Ride Mode");
		}
		else if (GameManager.Instance.gameStatus == GAME_STATUS.GAME_PLAY && GameManager.Instance.GameMode == GAME_MODE.LEVELS) 
		{
			levels [GameManager.Instance.currentLevel - 1].gameObject.SetActive (true);	
			GameManager.player.transform.position = levels [GameManager.Instance.currentLevel - 1].playerSpawningPoint.position;
			GameManager.player.transform.rotation = levels [GameManager.Instance.currentLevel - 1].playerSpawningPoint.rotation;
			GameManager.player.Arrow.Target = levels [GameManager.Instance.currentLevel - 1].FinishPoint;

			switch (GameManager.Instance.mode) 
			{
				case 1:
					GameManager.TIMER.RemainingTime -= 0;
					break;
				case 2:
					GameManager.TIMER.RemainingTime -= GameManager.TIMER.RemainingTime / 2;
					break;
				case 3:
					GameManager.TIMER.RemainingTime -= GameManager.TIMER.RemainingTime / 3;
					break;
			}

			GameManager.TIMER.RemainingTime = levels [GameManager.Instance.currentLevel - 1].LevelTime;
			StartCoroutine (GameManager.TIMER.StartTime());

			if (GameManager.Instance.currentLevel == 2 ||
				GameManager.Instance.currentLevel == 3 ||
				GameManager.Instance.currentLevel == 4 
				) 
			{
				GameManager.player.RCC.engineTorque = 10000;
			}
			//ConsoliAds.Instance.firebase.LogEvent("Game Play", "Start", "Level: " + GameManager.Instance.currentLevel.ToString());
		}

	}
	



}
