using UnityEngine;
using System.Collections;

public class BearController : MonoBehaviour {
	public float movementSpeed = 10;
	public float turningSpeed = 60;
	private Animator animator;
	private Rigidbody playerBody;
	private Vector3 movement;

	void Awake(){
		animator = transform.Find ("Walking").GetComponent<Animator> ();
		playerBody = transform.Find ("Walking").GetComponent<Rigidbody> ();
	}
	
	void Update() {
		/*float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
		
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical*-1);*/


		//Animating
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Move (h, v);
		Animate (h, v);
	}

	void Move(float h, float v){
		movement.Set(0, 0, v*-1);
		movement = movement.normalized * movementSpeed * Time.deltaTime;
		//playerBody.MovePosition (transform.position + movement);
		transform.Translate (movement);
	}

	void Animate(float h, float v){
		bool walking = h != 0f || v != 0f;
		animator.SetBool ("IsWalking", walking);
	}
}
