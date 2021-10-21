using UnityEngine;

public class PlaceableSurface : Placeable
{
	[SerializeField]
	private string hoverName;
	[SerializeField]
	private Transform itemParent;

	public override PlaceInfo WouldTake(Pickupable item)
	{
		return PlaceInfo.Success("place on " + hoverName);
	}
	public override PlaceInfo WouldGive(Pickupable item)
	{
		return PlaceInfo.Success("pickup " + item.name);
	}

	public override void Take(Pickupable item, Vector3 place)
	{
		//get the rotation eulers before reparenting
		Vector3 eulers = item.transform.rotation.eulerAngles;

		//set the item parent
		item.transform.SetParent(itemParent);

		//set rigidbody to kinematic
		Rigidbody rb = item.GetComponent<Rigidbody>();
		if (rb != null)
		{
			rb.isKinematic = false;
			item.GetComponent<Collider>().isTrigger = false;
		}

		//reset local position and rotation
		item.transform.rotation = Quaternion.Euler(0, eulers.y, 0);
		item.transform.position = place + item.bottom.localPosition + Vector3.up * 0.05f;

	}
	public override void Give(Pickupable item)
	{
		//Nothing to do.
	}

}
