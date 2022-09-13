using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  GamePlayUI: UIScreen 
{

	public void OnPauseButton()
	{
		GameManager.Instance.buttonSound.Play ();
		GameManager.Instance.gameStatus = GAME_STATUS.PAUSE;
		GameManager.UI.Show (SCREEN_NAME.PAUSE);
	}




}
