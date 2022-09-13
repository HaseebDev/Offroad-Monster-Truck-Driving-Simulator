using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBehaviour : MonoBehaviour {

	public Transform Target { get; set;}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (Target);
	}
}
