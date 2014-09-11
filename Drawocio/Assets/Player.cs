using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class Player : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f,0.0f);
		rigidbody.velocity = movement * speed;
		
		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 			 
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax));
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

		if(Input.GetKey(KeyCode.UpArrow))
		{
			rigidbody.velocity = new Vector3(0,1,0);
		}
	}
}