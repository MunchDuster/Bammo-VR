using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public string itemName;
	public string hoverInfo;
	public bool pickupable;
	public bool interactsWithPlayer;//If not, ca onl interact with item player is using

	public void InteractWith(PlayerInteract player, Interactable other = null)
	{
		if (other == null)
		{
			InteractWithPlayer(player);
		}
		else
		{
			InteractWithOther(other);
		}
	}

	public string WouldInteract(PlayerInteract player, Interactable other = null)
	{
		if (other == null)
		{
			if(interactsWithPlayer)
			{
				return WouldInteractWithPlayer(player);
			}
			else
			{
				return null;
			}
		}
		else
		{
			return WouldInteractWithOther(other);
		}
	}

	public abstract bool CanHoldItem(Interactable item);
	public abstract InteractionInfo TakeItem(Interactable item);

	protected abstract string WouldInteractWithOther(Interactable other);
	protected abstract string WouldInteractWithPlayer(PlayerInteract player);

	protected abstract InteractionInfo InteractWithOther(Interactable other);
	protected abstract InteractionInfo InteractWithPlayer(PlayerInteract player);
}
