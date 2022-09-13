using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

//	[SerializeField]
//	private Text musicText;
//	[SerializeField]
//	private Text soundText;
	[SerializeField]
	private Text controllerText;
	[SerializeField]
	private Text modeText;

	[SerializeField]
	private Sprite onSprite;
	[SerializeField]
	private Sprite offSprite;

	[SerializeField]
	private Image soundImage;
	[SerializeField]
	private Image musicImage;

	int modeNumber = 1;
	int controllerNumber = 1;

	public void Start()
	{
//		musicText.text = "ON";
//		soundText.text = "ON";

		controllerText.text = "BUTTONS";
		modeText.text = "EASY";
		musicImage.sprite = onSprite;
		soundImage.sprite = onSprite;
	}


	public void OnSoundButton()
	{GameManager.Instance.buttonSound.Play ();
		
		if (GameManager.Instance.isSound) {
//			soundText.text = "OFF";
			soundImage.sprite = offSprite;
			GameManager.Instance.isSound = false;
		} else {
//			soundText.text = "ON";
			soundImage.sprite = onSprite;
			GameManager.Instance.isSound = true;

		}
	}

	public void OnMusicButton()
	{GameManager.Instance.buttonSound.Play ();
		
		if (!AudioListener.pause) {
//			musicText.text = "OFF";
			musicImage.sprite = offSprite;
			AudioListener.pause = true;
		} else {
//			musicText.text = "ON";
			AudioListener.pause = false;
			musicImage.sprite = onSprite;

		}
	}

	public void OnControlsButton()
	{
		GameManager.Instance.buttonSound.Play ();
		
		if (controllerNumber == 3)
			controllerNumber = 1;
		else
			controllerNumber++;
		
		switch (controllerNumber) 
		{
		case 1:
			controllerText.text = "ARROWS";
			break;
		case 2:
			controllerText.text = "ACCELEROMETER";
			break;
		case 3:
			controllerText.text = "STEERING";
			break;


		}
		GameManager.Instance.controlsType = controllerNumber;
	}

	public void OnModeButton ()
	{GameManager.Instance.buttonSound.Play ();
		
		if (modeNumber == 3)
			modeNumber = 1;
		else
			modeNumber++;

		switch (modeNumber) 
		{
		case 1:
			modeText.text = "EASY";
			break;
		case 2:
			modeText.text = "NORMAL";
			break;
		case 3:
			modeText.text = "HARD";
			break;


		}
		GameManager.Instance.mode = modeNumber;
	}


	public void OnMenuButton()
	{GameManager.Instance.buttonSound.Play ();
		
		GameManager.UI.Show (SCREEN_NAME.MAIN_MENU);
	}
}
