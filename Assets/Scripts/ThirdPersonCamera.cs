using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

	public GameObject target;
	public float sensitivity = 5;
	public float maximumZAxis = -35;
	public float minimumZAxis = 20;

	Vector3 offset;
	float z,y;

	void Start () {
		offset = target.transform.position - transform.position;
	}

	void LateUpdate () {
		float horizontal = Input.GetAxis("Mouse X") * sensitivity;
		float vertical = Input.GetAxis("Mouse Y") * sensitivity;

		y += horizontal;
		z += vertical;

		if (z <= maximumZAxis) {
			z = maximumZAxis;
		}
		if (z >= minimumZAxis) {
			z = minimumZAxis;
		}
	
		Quaternion rotation = Quaternion.Euler(0, y, z);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);
	}

}
