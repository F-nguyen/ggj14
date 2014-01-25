using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float damping = 1;
	
	float offsetZ;
	Vector3 currentVelocity;
	
	// Use this for initialization
	void Start () {
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.position = Vector3.SmoothDamp(transform.position, target.position + Vector3.forward * offsetZ, ref currentVelocity, damping);
		transform.position = target.position + Vector3.forward * offsetZ; //Vector3.SmoothDamp(transform.position, target.position + Vector3.forward * offsetZ, ref currentVelocity, damping);
	}
}