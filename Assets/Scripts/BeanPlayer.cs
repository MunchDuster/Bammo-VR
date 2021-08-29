using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
TO DO
*/
public class BeanPlayer : MonoBehaviour
{
	[Header("Main")]
	public InputManager input;
	public Rigidbody rb;

	[Header("Movement")]
	public float moveSpeed = 10;
	public float turnSensitivity = 3;
	public Transform head;

	[Header("Interaction")]
	public float mouseRayMaxDistance = 1.5f;
	public Interactable curTool;
	public Camera cam;

	//private vars to be editted in inspector
	[SerializeField]
	private LayerMask mouseInteractLayerMask;
	[SerializeField]
	private ShowInteract interactionUI;
	[SerializeField]
	private Transform itemParent;

	//private vars
	private Interactable currentHoverItem;

	// Start is called before the first frame update
	void Start()
	{
		Cursor.visible = false;

		//assign functions to delegates
		input.OnInteractPressed += OnInteractPressed;
		input.OnPickupPressed += OnPickupPressed;
	}
	void OnDestroy()
	{
		//remove functions from delegates
		input.OnInteractPressed -= OnInteractPressed;
		input.OnPickupPressed -= OnPickupPressed;
	}

	void OnInteractPressed()
	{
		if(currentHoverItem == null) return;
		currentHoverItem.InteractWith(this, curTool);
	}
	void OnPickupPressed()
	{
		if(currentHoverItem == null || curTool != null) return;
		PickUp(currentHoverItem);
	}

	private Vector3 curEuler;
	//var to check if interactable object changed, instead of updating interact ui every frame
	private InteractionInfo currentInteractionInfo;


	// Update is called once per frame
	void Update()
	{
		Vector3 pos = Camera.main.transform.position;
		Vector3 dir = Camera.main.transform.forward;

		Ray ray = new Ray(pos,dir);
		
		if (Physics.Raycast(ray, out RaycastHit hit, mouseRayMaxDistance, mouseInteractLayerMask))
		{
			Debug.DrawRay(pos,dir * hit.distance, Color.red);
			Interactable interableItem = hit.transform.gameObject.GetComponent<Interactable>();

			currentHoverItem = interableItem;

			interactionUI.HoverInteractable(interableItem);
		}
		else
		{
			currentHoverItem = null;

			Debug.DrawRay(pos,dir * mouseRayMaxDistance, Color.green);
			interactionUI.Hide();
		}

		//LOOKING//

		//rotate head on x-axis (Up and down)
		float XturnAmount = input.look.y * Time.deltaTime * turnSensitivity;
		curEuler = Vector3.right * Mathf.Clamp( curEuler.x - XturnAmount, -90f, 90f);
		head.localRotation = Quaternion.Euler(curEuler);//.Rotate(verticalLookEuler * Time.deltaTime * turnSensitivity);

		//rotate body on y-axis (Sideways)
		float YturnAmount = input.look.x * Time.deltaTime * turnSensitivity;
		transform.Rotate(Vector3.up * YturnAmount);
	}
	
	
	//Pickup an item
	private void PickUp(Interactable item)
	{
		Debug.Log("PICKUP");
		item.transform.SetParent(itemParent);
		item.transform.localPosition = Vector3.zero;
		curTool = item;
	}
	
	//Fixed Update is called once per physics loop
	void FixedUpdate()
	{
		//MOVEMENT//

		//get raw input
		Vector3 rawDirection = new Vector3(input.move.x, 0, input.move.y);

		//calculate force relactive to player forward
		Vector3 moveForce = transform.TransformDirection(rawDirection * moveSpeed);

		//remove force from y axis
		Vector3 applyForce = Vector3.Scale(moveForce - rb.velocity, new Vector3(1,0,1));

		//Apply to rigidbody
		rb.AddForce(applyForce, ForceMode.VelocityChange);
	}
}
