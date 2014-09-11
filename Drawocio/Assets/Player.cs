using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class Player : MonoBehaviour
{
	private float walkspeed = 5.0f;
	private float jumpheight = 250.0f;
	private bool grounded = false;
	
	void Start() {
		
	}
	
	void Update() {
		
		rigidbody.freezeRotation = true;
		
		if (Input.GetKey(KeyCode.W)) rigidbody.position = rigidbody.position + (new Vector3(0, 0,-1) * Time.deltaTime * walkspeed);
		if (Input.GetKey(KeyCode.S)) rigidbody.position = rigidbody.position + (new Vector3(0, 0,1) * Time.deltaTime * walkspeed);
		if (Input.GetKey(KeyCode.A)) rigidbody.position = rigidbody.position + (new Vector3(1, 0, 0) * Time.deltaTime * walkspeed);
		if (Input.GetKey(KeyCode.D)) rigidbody.position = rigidbody.position + (new Vector3(-1, 0, 0) * Time.deltaTime * walkspeed);
		
		if (Input.GetKey(KeyCode.UpArrow)) {
			Jump();
		}
	}
	
	void OnCollisionEnter(Collision hit) {
		grounded = true;
		Debug.Log ("hit wall");
	}
	
	void Jump() {
		if (grounded == true) {
			rigidbody.AddForce(Vector3.up * jumpheight);
			grounded = false;
		}
	}
}