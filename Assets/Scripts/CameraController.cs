using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
	}

	void LateUpdate(){
		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0);

		float desiredAngle = target.transform.eulerAngles.y;
		Debug.Log (desiredAngle);
		Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
		Debug.Log (rotation);
		transform.position = target.transform.position - (rotation * offset);

		transform.LookAt (target.transform);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
