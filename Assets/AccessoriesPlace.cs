using System.Collections.Generic;
using UnityEngine;

public class AccessoriesPlace : Interactable
{
	[System.Serializable]
	private struct Accessory
	{
		public Transform item;
		public Transform place;
		public Criteria wearCriteria;
	}

	public UnityEngine.Events.UnityEvent OnInteract;
	public Criteria criteriaMetWhenNotWearingAnything;

	[SerializeField]
	private Accessory[] accessories;


	public override InteractionInfo WouldInteract(PlayerInteract player)
	{
		Accessory[] wearingAccessories = GetWearingAccessories();

		if (wearingAccessories.Length == 0)
			return InteractionInfo.Problem("nothing to put back");
		else
			return InteractionInfo.Success("place safety equipment");
	}
	public override void Interact(PlayerInteract player)
	{
		if (OnInteract != null) OnInteract.Invoke();
		foreach (Accessory accessory in GetWearingAccessories())
		{
			accessory.item.SetParent(transform);
			accessory.item.position = accessory.place.position;
			accessory.item.rotation = accessory.place.rotation;
		}
		criteriaMetWhenNotWearingAnything.hasBeenMet = true;
	}

	private Accessory[] GetWearingAccessories()
	{
		List<Accessory> wearing = new List<Accessory>();
		foreach (Accessory accessory in accessories)
		{
			if (accessory.wearCriteria.hasBeenMet)
			{
				wearing.Add(accessory);
			}
		}
		return wearing.ToArray();
	}
}
