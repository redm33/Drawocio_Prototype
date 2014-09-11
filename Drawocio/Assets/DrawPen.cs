using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawPen : MonoBehaviour {

	private LineRenderer line;
	private bool isMousePressed;
	private List<Vector3> pointsList;
	private Vector3 mousePos;
	public GameObject prefab;
	public GameObject ink;
	public GameObject charcoal;
	private float lastX;
	private float lastY;
	private float firstX;
	private float firstY;
	private bool firstPos;
	private List<GameObject> art;
	//private List<List<GameObject>> art;
	
	// Structure for line points
	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	};
	//    -----------------------------------    
	void Awake()
	{
		isMousePressed = false;
		pointsList = new List<Vector3>();
		art = new List<GameObject> ();
		//art = new List<List<GameObject>> ();
		firstPos = true;
		lastY = -1000000f;
		lastX = 1000000f;
	}
	//    -----------------------------------    
	void Update () 
	{
		// If mouse button down, remove old line and set its color to green
		Pen ();
		Pencil ();
		Charcoal ();
		ModePlay ();

	}
	void Pencil()
	{
		if(Input.GetKey(KeyCode.L))
		{
			if(Input.GetMouseButtonDown(0))
			{
				isMousePressed = true;
			}
			else if(Input.GetMouseButtonUp(0))
			{
				isMousePressed = false;
				firstPos = true;

				for(int i = 0; i < art.ToArray().Length-1; i++)
				{
					ConfigurableJoint joint = art[i].AddComponent<ConfigurableJoint>();
					joint.xMotion = ConfigurableJointMotion.Locked;
					joint.yMotion = ConfigurableJointMotion.Locked;
					joint.zMotion = ConfigurableJointMotion.Locked;
					joint.angularXMotion = ConfigurableJointMotion.Locked;
					joint.angularYMotion = ConfigurableJointMotion.Locked;
					joint.angularZMotion = ConfigurableJointMotion.Locked;
					joint.targetPosition = new Vector3(0, 0, 0);
					joint.projectionMode = JointProjectionMode.PositionOnly;
					joint.projectionDistance = .2f;
					joint.connectedBody = art[i+1].rigidbody;

				}
				if(Mathf.Abs(firstX-lastX) <= 3 && Mathf.Abs(firstY-lastY) <= 3)
				{
					ConfigurableJoint joint = art[art.ToArray().Length - 1].AddComponent<ConfigurableJoint>();
					joint.xMotion = ConfigurableJointMotion.Locked;
					joint.yMotion = ConfigurableJointMotion.Locked;
					joint.zMotion = ConfigurableJointMotion.Locked;
					joint.angularXMotion = ConfigurableJointMotion.Locked;
					joint.angularYMotion = ConfigurableJointMotion.Locked;
					joint.angularZMotion = ConfigurableJointMotion.Locked;
					joint.targetPosition = new Vector3(0, 0, 0);
					joint.projectionMode = JointProjectionMode.PositionOnly;
					joint.projectionDistance = .2f;
					joint.connectedBody = art[0].rigidbody;
				}
			}
			// Drawing line when mouse is moving(presses)
			if(isMousePressed)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (gameObject.collider.Raycast (ray, out hit, Mathf.Infinity)) {
					mousePos = hit.point;
					mousePos.z = mousePos.z + 1f;
					if(firstPos)
					{
						firstX = mousePos.x;
						firstY = mousePos.y;
					}
					float distanceY = Mathf.Abs(lastY - mousePos.y);
					float distanceX = Mathf.Abs(lastX - mousePos.x);

					if(firstPos || distanceY >= .1f || distanceX >= .1f){
						Debug.Log (distanceX);
						Debug.Log (distanceY);
						GameObject newCube = Instantiate(prefab, mousePos, Quaternion.identity) as GameObject;
						art.Add(newCube);
						lastY = mousePos.y;
						lastX = mousePos.x;

					}
				}
				firstPos = false;
			}
		}

	}
	void Pen()
	{
		if(Input.GetKey(KeyCode.I))
		{
			if(Input.GetMouseButtonDown(0))
			{
				isMousePressed = true;
			}
			else if(Input.GetMouseButtonUp(0))
			{
				isMousePressed = false;
				firstPos = true;
				
				for(int i = 0; i < art.ToArray().Length-1; i++)
				{
					ConfigurableJoint joint = art[i].AddComponent<ConfigurableJoint>();
					joint.xMotion = ConfigurableJointMotion.Locked;
					joint.yMotion = ConfigurableJointMotion.Locked;
					joint.zMotion = ConfigurableJointMotion.Locked;
					joint.angularXMotion = ConfigurableJointMotion.Locked;
					joint.angularYMotion = ConfigurableJointMotion.Locked;
					joint.angularZMotion = ConfigurableJointMotion.Locked;
					joint.targetPosition = new Vector3(0, 0, 0);
					joint.projectionMode = JointProjectionMode.PositionOnly;
					joint.projectionDistance = .01f;
					joint.connectedBody = art[i+1].rigidbody;
					
				}
				if(Mathf.Abs(firstX-lastX) <= 3 && Mathf.Abs(firstY-lastY) <= 3)
				{
					ConfigurableJoint joint = art[art.ToArray().Length - 1].AddComponent<ConfigurableJoint>();
					joint.xMotion = ConfigurableJointMotion.Locked;
					joint.yMotion = ConfigurableJointMotion.Locked;
					joint.zMotion = ConfigurableJointMotion.Locked;
					joint.angularXMotion = ConfigurableJointMotion.Locked;
					joint.angularYMotion = ConfigurableJointMotion.Locked;
					joint.angularZMotion = ConfigurableJointMotion.Locked;
					joint.targetPosition = new Vector3(0, 0, 0);
					joint.projectionMode = JointProjectionMode.PositionOnly;
					joint.projectionDistance = .01f;
					joint.connectedBody = art[0].rigidbody;
				}
			}
			// Drawing line when mouse is moving(presses)
			if(isMousePressed)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (gameObject.collider.Raycast (ray, out hit, Mathf.Infinity)) {
					mousePos = hit.point;
					mousePos.z = mousePos.z + 1f;
					if(firstPos)
					{
						firstX = mousePos.x;
						firstY = mousePos.y;
					}
					float distanceY = Mathf.Abs(lastY - mousePos.y);
					float distanceX = Mathf.Abs(lastX - mousePos.x);
					
					if(firstPos || distanceY >= .1f || distanceX >= .1f){
						Debug.Log (distanceX);
						Debug.Log (distanceY);
						GameObject newCube = Instantiate(ink, mousePos, Quaternion.identity) as GameObject;
						art.Add(newCube);
						lastY = mousePos.y;
						lastX = mousePos.x;
						
					}
				}
				firstPos = false;
			}
		}
	}

	void Charcoal()
	{
		if(Input.GetKey(KeyCode.C))
		{
			if(Input.GetMouseButtonDown(0))
			{
				isMousePressed = true;
			}
			else if(Input.GetMouseButtonUp(0))
			{
				isMousePressed = false;
				firstPos = true;

				for(int i = 0; i < art.ToArray().Length-1; i++)
				{
					ConfigurableJoint joint = art[i].AddComponent<ConfigurableJoint>();
					joint.xMotion = ConfigurableJointMotion.Locked;
					joint.yMotion = ConfigurableJointMotion.Locked;
					joint.zMotion = ConfigurableJointMotion.Locked;
					joint.angularXMotion = ConfigurableJointMotion.Locked;
					joint.angularYMotion = ConfigurableJointMotion.Locked;
					joint.angularZMotion = ConfigurableJointMotion.Locked;
					joint.targetPosition = new Vector3(0, 0, 0);
					joint.connectedBody = art[i+1].rigidbody;
				}


			}
			// Drawing line when mouse is moving(presses)
			if(isMousePressed)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (gameObject.collider.Raycast (ray, out hit, Mathf.Infinity)) {
					mousePos = hit.point;
					mousePos.z = mousePos.z + 1f;
					if(firstPos)
					{
						firstX = mousePos.x;
						firstY = mousePos.y;
					}
					float distanceY = Mathf.Abs(lastY - mousePos.y);
					float distanceX = Mathf.Abs(lastX - mousePos.x);
					
					if(firstPos || distanceY >= .1f || distanceX >= .1f){
						Debug.Log (distanceX);
						Debug.Log (distanceY);
						GameObject newCube = Instantiate(charcoal, mousePos, Quaternion.identity) as GameObject;
						art.Add(newCube);
						lastY = mousePos.y;
						lastX = mousePos.x;
						
					}
				}
				firstPos = false;
			}

		}


	}

	void ModePlay()
	{
		if (Input.GetKey (KeyCode.Space)) {

			foreach (var value in art)
			{
					value.rigidbody.useGravity = true;
					value.rigidbody.isKinematic = false;

			}
			art.Clear ();



		}

	}

}
