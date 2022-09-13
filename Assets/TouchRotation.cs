using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotation : MonoBehaviour {

	public float speed = 10;
	public float cameraRotationSpeed = 5;
	public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
	public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.


	bool isZoom = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		float pointer_x = Input.GetAxis("Mouse X");
		float pointer_y = Input.GetAxis("Mouse Y");
		if (Input.touchCount > 0)
		{
			pointer_x = Input.touches[0].deltaPosition.x;
			pointer_y = Input.touches[0].deltaPosition.y;
		}

		float h = pointer_x; //Input.GetAxis ("Horizontal");
		float v = pointer_y; //Input.GetAxis ("Vertical");
//		float h = Input.GetAxis ("Horizontal");
//		float v = Input.GetAxis ("Vertical");
		if (!isZoom)
		{
			if (h != 0) {
				transform.Rotate (- transform.up * Time.deltaTime * h * speed);
			} else {
				transform.Rotate (transform.up * Time.deltaTime * 10);
			}
			//Debug.Log (Camera.main.transform.localEulerAngles.x + v.ToString());
			if ((Camera.main.transform.localEulerAngles.x + v) > 3 && (Camera.main.transform.localEulerAngles.x + v) < 25 && (v > 0.5 || v < 0.5))
				Camera.main.transform.localEulerAngles += new Vector3 (v * Time.deltaTime * cameraRotationSpeed, 0, 0);
		}

		if (Input.touchCount == 2)
		{
			isZoom = true;
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// If the camera is orthographic...
			if (Camera.main.orthographic)
			{
				// ... change the orthographic size based on the change in distance between the touches.
				Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

				// Make sure the orthographic size never drops below zero.
				Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
			}
			else
			{
				// Otherwise change the field of view based on the change in distance between the touches.
				Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed * 0.5f;

				// Clamp the field of view to make sure it's between 0 and 180.
				Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView,35, 70);
			}
		} else {
			isZoom = false;
		}
	}
}
