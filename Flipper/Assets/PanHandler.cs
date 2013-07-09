using UnityEngine;
using System.Collections;

public class PanHandler : MonoBehaviour {
	
	private static float speed = 10.0f;
	private static float accelerometerUpdateInterval = 1.0f / 60.0f;
	private static float lowPassKernelWidthInSeconds = 1.0f;
	private float lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
	private Vector3 lowPassValue = Vector3.zero;
	
	void Start () {
		lowPassValue = Input.acceleration;
		gameObject.rigidbody.centerOfMass = new Vector3(0,0,-5);
	}
	
	private Vector3 lowPassFilterAccelerometer()
	{
		lowPassValue.x = Mathf.Lerp(lowPassValue.x, Input.acceleration.x, lowPassFilterFactor);
		lowPassValue.y = Mathf.Lerp(lowPassValue.y, Input.acceleration.y, lowPassFilterFactor);
		lowPassValue.z = Mathf.Lerp(lowPassValue.z, Input.acceleration.z, lowPassFilterFactor);
		return lowPassValue;
	}
	
	void Update () {
		
		Vector3 downForce = new Vector3(0,-2,0);
		Vector3 downPosition = new Vector3(0,0,20);
		
		gameObject.rigidbody.AddForceAtPosition(downForce, downPosition, ForceMode.Force);

		
		Vector3 upForce = new Vector3(0,2,0);
		Vector3 upPosition = new Vector3(0,0,18);
		
		gameObject.rigidbody.AddForceAtPosition(upForce, upPosition, ForceMode.Force);

	}
	
}
