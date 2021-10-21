using UnityEngine;

public class Pickupable : MonoBehaviour
{
	public Transform bottom;

	public bool canBePickUp = true;
	public string cantPickUpReason = "Reason can't pick up.";

	public PlaceInfo CanPickup()
	{
		return (canBePickUp) ? PlaceInfo.Success("pickup " + this.name) : PlaceInfo.Problem(cantPickUpReason);
	}
}
