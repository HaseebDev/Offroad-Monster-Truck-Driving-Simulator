using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour
{

	public SCREEN_NAME Name;//{ get; set;}
	private ITweenBehaviour tweenBehaviour;
	public bool isTimeScaleSetZero = false;
	// Use this for initialization
	void Awake () 
	{
		tweenBehaviour = GetComponent<ITweenBehaviour> ();
	}

	public virtual void OnEnable()
	{
		if(tweenBehaviour != null)
			tweenBehaviour.Show ();
		else {
			if (isTimeScaleSetZero) {
				Time.timeScale = 0;
			}
		}
	}

	public void HideScreen()
	{
		if (tweenBehaviour != null)
			tweenBehaviour.Hide ();
		else
			gameObject.SetActive (false);
	}

	public virtual void OnMenuButton()
	{Time.timeScale = 1;
		GameManager.Instance.buttonSound.Play ();
		
		GameManager.Instance.gameStatus = GAME_STATUS.BEGIN;

		Application.LoadLevel (Application.loadedLevel - 1);
	}

	public virtual void OnRestartButton()
	{Time.timeScale = 1;
		GameManager.Instance.buttonSound.Play ();

		GameManager.Instance.gameStatus = GAME_STATUS.GAME_PLAY;

		Application.LoadLevel (Application.loadedLevel);

	}

	public virtual void OnResumeButton()
	{
		GameManager.Instance.buttonSound.Play ();
		GameManager.Instance.gameStatus = GAME_STATUS.GAME_PLAY;
		Time.timeScale = 1;
		GameManager.UI.Show (SCREEN_NAME.GAME_PLAY);
	}
}
