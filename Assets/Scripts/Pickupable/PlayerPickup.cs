using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerTool))]
[RequireComponent(typeof(PlayerSense))]
[RequireComponent(typeof(UserInput))]
public class PlayerPickup : MonoBehaviour
{
	public PlayerUI interactionUI;

	public UnityEvent OnPickup;
	public UnityEvent OnPlace;
	public UnityEvent OnHoverStart;
	public UnityEvent OnHoverEnd;

	private InputManager input;
	private PlayerSense sensor;
	private PlayerTool tool;

	[SerializeField]
	private Transform itemParent;

	[SerializeField]
	private LayerMask SetToLayer;

	private Placeable placeableHover;
	private Pickupable pickupableHover;
	private bool colliderWasTrigger;
	private LayerMask colliderPrevLayer;

	private void Start()
	{
		//get components from gameobject
		sensor = GetComponent<PlayerSense>();
		input = GetComponent<UserInput>();
		tool = GetComponent<PlayerTool>();

		//assign functions to delegates
		input.OnPickupPressed += OnPickupPressed;
	}
	// Called on late update in 
	private void LateUpdate()
	{
		/**
		1. Check if hovering over placeable
		2. Check if hovering over pickupable
		*/
		if (sensor.hoverObject == null)
		{
			interactionUI.HidePickupable();
			return;
		}

		//FIRST CHECK IF HOVERING OVER PLACEABLE
		placeableHover = sensor.hoverObject.GetComponent<Placeable>();
		if (tool.toolPickupable != null && placeableHover != null)
		{
			//hover object is placeable and player is holding item
			PlaceInfo placeInfo = placeableHover.WouldTake(tool.toolPickupable);

			if (placeInfo.type == PlaceInfo.Type.Success)
			{
				interactionUI.ShowPickupable(placeInfo.message);
				return;
			}
		}

		//NOW CHECK IF HOVERING OVER PICKUPABLE
		pickupableHover = sensor.hoverObject.GetComponent<Pickupable>();

		//if is hovering over pickupable (and it will be picked up) and not holding anything
		if (pickupableHover != null && tool.curTool == null)
		{
			PlaceInfo placeInfo = pickupableHover.CanPickup();
			if (placeInfo.type == PlaceInfo.Type.Success)
			{
				interactionUI.ShowPickupable(placeInfo.message);
				return;
			}
		}

		//NEITHER DONE, HIDE PICKUPABLE INFO
		interactionUI.HidePickupable();
	}
	//Place current tool
	private void Place()
	{
		//reset the collider
		Collider col = tool.curTool.gameObject.GetComponent<Collider>();
		if (!colliderWasTrigger)
		{
			col.isTrigger = false;
		}
		tool.curTool.gameObject.layer = colliderPrevLayer;

		if (OnPlace != null) OnPlace.Invoke();

		Pickupable pickup = tool.toolPickupable;
		placeableHover.Take(pickup, sensor.hoverPoint);
		tool.SetNull();
	}
	//Pickup the hover item
	private void Pickup(Pickupable item)
	{
		if (OnPickup != null) OnPickup.Invoke();

		item.transform.SetParent(itemParent);

		item.transform.localPosition = Vector3.zero;
		item.transform.localRotation = Quaternion.identity;

		tool.SetFromPickupable(item);

		Rigidbody rb = item.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.isKinematic = true;
			rb.AddForce(Random.onUnitSphere * 0.02f);
		}

		//Make sure the collider does not have collision or with raycasts
		Collider col = item.GetComponent<Collider>();
		colliderPrevLayer = item.gameObject.layer;
		item.gameObject.layer = SetToLayer;
		if (col.isTrigger)
		{
			colliderWasTrigger = true;
		}
		else
		{
			colliderWasTrigger = false;
			col.isTrigger = true;
		}
	}
	//Listener for when player presses pickup button
	private void OnPickupPressed()
	{
		//if player can place an item then try placing, if not,check if player can pick up an item
		if (tool.curTool != null)
		{
			if (placeableHover != null)
			{
				if (canPlace())
				{
					Place();
				}
			}
		}
		else
		{
			if (pickupableHover == null) return;
			Pickup(pickupableHover);
		}
	}
	private bool canPlace()
	{
		if (tool.curTool == null || placeableHover == null) return false;


		PlaceInfo info = placeableHover.WouldTake(tool.toolPickupable);

		if (info.type == PlaceInfo.Type.Success)
		{
			return true;
		}
		else if (info.type == PlaceInfo.Type.Problem)
		{
			interactionUI.Problem(info.message);
			return false;
		}
		return false;



	}
	private void OnDestroy()
	{
		//remove functions from delegates
		input.OnPickupPressed -= OnPickupPressed;
	}
};