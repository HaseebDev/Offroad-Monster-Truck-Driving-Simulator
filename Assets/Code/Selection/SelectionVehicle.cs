using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionVehicle : MonoBehaviour
{
	Vector3 initPosition;

	void Awake()
	{
		initPosition = transform.position;
	}

	// Use this for initialization
	void Start () 
	{
		
	}

	void OnEnable()
	{
		transform.position = initPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (transform.up * Time.deltaTime * 20);
	}
}
