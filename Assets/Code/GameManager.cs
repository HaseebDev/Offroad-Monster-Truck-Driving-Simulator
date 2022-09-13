using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	public static UIManager UI;
	public static Player player;
	public static Timer TIMER;
	public int currentLevel = 1;

	public int interstitialAdCounter = 0;

	public int levelRemainingTime = 0;

	public static bool isVideoShown = false;

	public GAME_STATUS gameStatus = GAME_STATUS.BEGIN;
	public int selectedVehicle = 1;
	public bool isSound = true;
	public int controlsType = 1;
	public int levelStars = 0;
	//public bool isFreeRide = false;
	public GAME_MODE GameMode = GAME_MODE.LEVELS;

	public int mode = 1;

	public AudioSource buttonSound;

	public override void Awake()
	{
		base.Awake ();
	}
}


public enum GAME_STATUS 
{
	BEGIN,
	GAME_OVER,
	SUCCESS,
	PAUSE,
	GAME_PLAY
}

public enum GAME_MODE
{
	GROUND_FREE_RIDE,
	HILL_FREE_RIDE,
	LEVELS
}