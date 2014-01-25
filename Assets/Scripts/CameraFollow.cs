using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float damping = 1;
	
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	
	// Use this for initialization
	void Start () {
		//lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, target.position + Vector3.forward * offsetZ, ref currentVelocity, damping);
	}
}