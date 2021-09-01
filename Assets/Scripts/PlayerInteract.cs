using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
TO DO
*/
public class PlayerInteract : MonoBehaviour
{
	public InputManager input;
	[Header("Interaction")]
	public float mouseRayMaxDistance = 1.5f;
	public Interactable curTool;
	public Camera cam;

	//private vars to be editted in inspector
	[SerializeField]
	private LayerMask mouseInteractLayerMask;
	
	public ShowInteract interactionUI;
	[SerializeField]
	private Transform itemParent;

	//private vars
	private Interactable currentHoverItem;

	// Start is called before the first frame update
	void Start()
	{
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
		if(currentHoverItem == null) return;
		//if player can place an item then show, if not,check if player can pijk up an item
		if(curTool != null)
		{
			if(canPlace())
			{
				Place();
			}	
		}
		else
		{
			PickUp(currentHoverItem);
		}
		
	}
	private bool canPlace()
	{
		if(curTool == null) return false;
		return currentHoverItem.CanHoldItem(curTool);
	}
	private void Place()
	{
		InteractionInfo info = currentHoverItem.TakeItem(curTool);
		if(info.type != InteractionType.Success)
		{

		}
		curTool = null;
	}
	//var to check if interactable object changed, instead of updating interact ui every frame
	private InteractionInfo currentInteractionInfo;


	// Update is called once per frame
	void Update()
	{
		//INTERACTABLE HOVER UPDATE
		
		Interactable interactable = Raycast();
		if (interactable != null)
		{
			//IS LOOKING AT AN INTERACTABLE
			HoverItem(interactable);
		}
		else
		{
			//IS NOT LOOKING AT AN INTERACTABLE
			NoHover();
		}
	}
	private Interactable Raycast()
	{
		Vector3 pos = Camera.main.transform.position;
		Vector3 dir = Camera.main.transform.forward;

		Ray ray = new Ray(pos,dir);
		if (Physics.Raycast(ray, out RaycastHit hit, mouseRayMaxDistance, mouseInteractLayerMask))
		{
			//Object hit
			Debug.DrawRay(pos,dir * hit.distance, Color.red);
			return hit.transform.gameObject.GetComponent<Interactable>();
		}
		else
		{
			//No object hit
			Debug.DrawRay(pos,dir * mouseRayMaxDistance, Color.green);
			return null;
		}
	}
	private void HoverItem(Interactable interactable)
	{
		currentHoverItem = interactable;
		interactionUI.ShowHover(interactable, canPlace());

		
				
		ShowPossibleInteraction();
	}
	private void NoHover()
	{
		currentHoverItem = null;
		interactionUI.HideHover();
		interactionUI.HideInteraction();
	}
	private void ShowPossibleInteraction()
	{
		string interactionName = currentHoverItem.WouldInteract(this, curTool);
		if(interactionName != null)
		{
			interactionUI.ShowInteraction(interactionName);
		}
		else
		{
			interactionUI.HideInteraction();
		}
	}
	//Pickup an item
	private void PickUp(Interactable item)
	{
		Debug.Log("PICKUP");
		item.transform.SetParent(itemParent);
		item.transform.localPosition = Vector3.zero;
		curTool = item;
	}
}
