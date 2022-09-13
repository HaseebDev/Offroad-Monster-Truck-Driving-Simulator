using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UITopBar : MonoBehaviour
{

	[SerializeField]
	private Text score;
	[SerializeField]
	private Text career;
	[SerializeField]
	private Text stars;


	// Use this for initialization
	void Start () 
	{
		
	}

	void OnEnable()
	{
		score.text = PlayerPrefs.GetInt (AppConstants.SCORES).ToString();
		career.text = PlayerPrefs.GetInt (AppConstants.LEVEL).ToString();
		stars.text = PlayerPrefs.GetInt (AppConstants.TOTAL_STARS).ToString();

	}


}
