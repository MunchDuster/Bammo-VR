using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
TO DO
1. Get input manager from drivey car

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
	public LayerMask mouseInteractLayerMask;
	public Camera cam;
	public ShowInteract interactionUI;
	public Interactable curTool;

	// Start is called before the first frame update
	void Start()
	{

	}

	//var to check if interactable object changed, instead of updating interact ui every frame
	InteractionInfo currentInteractionInfo;


	// Update is called once per frame
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hit, mouseRayMaxDistance, mouseInteractLayerMask))
		{
			Interactable interableItem = hit.transform.gameObject.GetComponent<Interactable>();

			if (input.interactPressed)
			{
				interableItem.InteractWith(this, curTool);
			}
			else
			{
				interactionUI.HoverInteractable(interableItem);
			}
		}
		else
		{
			interactionUI.Hide();
		}
	}
	//Fixed Update is called once per physics loop
	void FixedUpdate()
	{
		//MOVEMENT//
		Vector3 rawDirection = new Vector3(input.move.x, 0, input.move.y);
		Vector3 moveForce = transform.TransformDirection(rawDirection * moveSpeed);

		//Anti slide
		rb.AddForce(-rb.velocity, ForceMode.VelocityChange);

		//move 
		rb.AddForce(moveForce * Time.fixedDeltaTime, ForceMode.VelocityChange);

		//LOOKING//
		Vector3 verticalLookEuler = new Vector3(input.look.y, 0, 0);
		transform.Rotate(verticalLookEuler * Time.fixedDeltaTime);
		Vector3 sideLookEuler = new Vector3(0, input.look.x, 0);
		head.Rotate(sideLookEuler * Time.fixedDeltaTime);
	}
}
