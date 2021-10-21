using UnityEngine;

public abstract class Placeable : MonoBehaviour
{
	public abstract PlaceInfo WouldTake(Pickupable item);
	public abstract PlaceInfo WouldGive(Pickupable item);

	public abstract void Take(Pickupable item, Vector3 place);
	public abstract void Give(Pickupable item);
}
