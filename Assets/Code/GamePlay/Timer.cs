using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
	public float RemainingTime { get; set;}
	public Text GUITimer { get; set;}
	// Use this for initialization
	void Awake () 
	{
		GameManager.TIMER = this;
		GUITimer = GetComponent<Text> ();
	}


	public IEnumerator StartTime()
	{
		Debug.Log (RemainingTime.ToString()	);
		while (RemainingTime > 0)
		{
			yield return new WaitForSeconds (1);
			RemainingTime -= 1;
			System.TimeSpan time = System.TimeSpan.FromSeconds(RemainingTime);
			string str = time.ToString();
			GUITimer.text = str.Substring(3,5);
			if (RemainingTime == 0 && GameManager.Instance.gameStatus == GAME_STATUS.GAME_PLAY) 
			{
				GameManager.Instance.gameStatus = GAME_STATUS.GAME_OVER;
				GameManager.UI.Show (SCREEN_NAME.GAME_OVER);
			}
		}
	}


}
