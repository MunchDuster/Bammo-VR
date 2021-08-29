using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public string itemName;
	public string hoverInfo;

	public bool pickupable;

	public void InteractWith(BeanPlayer player, Interactable other = null)
	{
		if (other == null)
		{
			InteractWithPlayer();
		}
		else
		{
			InteractWithOther();
		}
	}
	public abstract void InteractWithOther();
	public abstract void InteractWithPlayer();
}
