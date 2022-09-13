using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Transform FollowdObject{ get; set;}
	public LookAtBehaviour Arrow { get; set;}
	public RCCCarControllerV2 RCC { get; set;}


	void Awake()
	{
		GameManager.player = this;
		FollowdObject = transform.Find ("FollowedObject");
		Arrow = transform.Find ("Arrow").GetComponent<LookAtBehaviour>();
		RCC = GetComponent<RCCCarControllerV2> ();

	}


		

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("FinishPoint") ) 
		{
			GameObject.FindObjectOfType<SmoothFollowCamera> ().target = null;
			StartCoroutine (CompleteLevel());

		}
		if (other.gameObject.CompareTag("DeadArea") ) 
		{
			GameObject.FindObjectOfType<SmoothFollowCamera> ().target = null;
			StartCoroutine (GameOver());
		}

	}

	public IEnumerator CompleteLevel()
	{
		yield return new WaitForSeconds (2);
		if (GameManager.Instance.gameStatus == GAME_STATUS.GAME_PLAY) {
			GetComponent<Rigidbody> ().isKinematic = true;

			GameController controller = GameObject.FindObjectOfType<GameController> ();

			if ((GameManager.TIMER.RemainingTime / controller.levels [GameManager.Instance.currentLevel - 1].LevelTime) * 100 > 60) 
			{
				GameManager.Instance.levelStars = 3;
			}
			else if ((GameManager.TIMER.RemainingTime / controller.levels [GameManager.Instance.currentLevel - 1].LevelTime) * 100 > 50) 
			{
				GameManager.Instance.levelStars = 2;
			}
			else 
			{
				GameManager.Instance.levelStars = 1;
			}
			GameManager.Instance.levelRemainingTime = (int)GameManager.TIMER.RemainingTime;
			GameManager.Instance.gameStatus = GAME_STATUS.SUCCESS;
			GameManager.UI.Show (SCREEN_NAME.LEVEL_COMPLETE);
		}
	}

	public IEnumerator GameOver()
	{
		yield return new WaitForSeconds (2);
		if (GameManager.Instance.gameStatus == GAME_STATUS.GAME_PLAY)
		{
			GetComponent<Rigidbody> ().isKinematic = true;
			GameManager.Instance.gameStatus = GAME_STATUS.GAME_OVER;
			GameManager.UI.Show (SCREEN_NAME.GAME_OVER);
		}
	}



}
