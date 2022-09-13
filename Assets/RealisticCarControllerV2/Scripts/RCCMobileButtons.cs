//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2015 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RCCMobileButtons : MonoBehaviour {

	public GameObject gasButton;
	public GameObject brakeButton;
	public GameObject leftButton;
	public GameObject rightButton;
	public GameObject steeringWheel;
	public GameObject handbrakeButton;
	public GameObject boostButton;

	public Sprite[] controlButtonSprites;
	public Image controlbuttonImage;

	public void ChangeCamera () {

		if(GameObject.FindObjectOfType<RCCCamManager>())
			GameObject.FindObjectOfType<RCCCamManager>().ChangeCamera();

	}

	void Start()
	{
		switch (GameManager.Instance.controlsType) 
		{

		case 1:
			controlbuttonImage.sprite = controlButtonSprites [0];
			break;
		case 2:
			controlbuttonImage.sprite = controlButtonSprites [1];
			break;
		case 3:
			controlbuttonImage.sprite = controlButtonSprites [2];
			break;
		}
	}

	public void OnControlsButton()
	{
		if (GameObject.FindObjectOfType<RCCCarControllerV2>().ControlType < 3) {
			GameObject.FindObjectOfType<RCCCarControllerV2> ().ControlType++;
		} else {
			GameObject.FindObjectOfType<RCCCarControllerV2> ().ControlType = 1;
		}
		switch (GameObject.FindObjectOfType<RCCCarControllerV2> ().ControlType)
		{
		case 1:
			controlbuttonImage.sprite = controlButtonSprites [0];
			break;
		case 2:
			controlbuttonImage.sprite = controlButtonSprites [1];
			break;
		case 3:
			controlbuttonImage.sprite = controlButtonSprites [2];
			break;
		}
	}

}
