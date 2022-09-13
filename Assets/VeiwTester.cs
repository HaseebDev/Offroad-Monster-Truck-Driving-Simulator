using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiwTester : MonoBehaviour {

	[SerializeField]
	private string objectTagToSee = "Player";
	[SerializeField]
	private float minimumDistance = 2;
	private float maximumDistance = 6.5f;
	[SerializeField]
	private float smoothTime =0.3F;
	private float velocity = 100;
	public SmoothFollowCamera FollowBehavoiur{ get; set;}

	private Vector3 interruptedPoint;

	void Awake()
	{
		FollowBehavoiur = GetComponent<SmoothFollowCamera> ();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	void Update() 
	{
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, 300)) 
			Debug.DrawLine(transform.position, hit.point);

		//Debug.Log (hit.collider.name);

		if (hit.collider == null)
			return;

		if (!hit.collider.gameObject.CompareTag (objectTagToSee) && hit.collider.GetComponent<Renderer> () != null && FollowBehavoiur.distance > minimumDistance) 
		{
			//smoothdamp!
			interruptedPoint = hit.point;
			FollowBehavoiur.distance = Mathf.SmoothDamp (FollowBehavoiur.distance, minimumDistance, ref velocity, smoothTime);
		} 
		else if (!hit.collider.gameObject.CompareTag (objectTagToSee) && hit.collider.name.Contains ("Terrain") && FollowBehavoiur.distance > minimumDistance) 
		{
			interruptedPoint = hit.point;
			FollowBehavoiur.distance = Mathf.SmoothDamp (FollowBehavoiur.distance, minimumDistance, ref velocity, smoothTime);

		}
		else if(hit.collider.gameObject.CompareTag(objectTagToSee) && FollowBehavoiur.distance < maximumDistance &&
			Vector3.Distance(transform.position, interruptedPoint) > (maximumDistance - minimumDistance)
		)
		{
			FollowBehavoiur.distance = Mathf.SmoothDamp (FollowBehavoiur.distance, maximumDistance, ref velocity, smoothTime);
		}


	}



}
