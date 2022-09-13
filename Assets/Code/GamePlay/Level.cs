using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour 
{
	public float LevelTime;
	public Transform playerSpawningPoint { get; set;}
	public Transform FinishPoint { get; set;}

	// Use this for initialization
	void Awake ()
	{
		playerSpawningPoint = transform.Find ("PlayerSpawningPoint");
		FinishPoint = transform.Find ("FinishPoint");
	}

	void Start()
	{
		//gameObject.SetActive (false);
	}


}






