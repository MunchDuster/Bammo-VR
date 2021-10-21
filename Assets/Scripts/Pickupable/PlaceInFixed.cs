using UnityEngine;

public class PlaceInFixed : Placeable
{
	private class ItemPlace
	{
		public Pickupable item;
		public Transform place;
	}

	public string[] acceptableItems;

	[SerializeField]
	private string hoverName;

	[SerializeField]
	private Transform[] places;
	[SerializeField]
	private Transform itemParent;

	private ItemPlace[] items;


	public override PlaceInfo WouldTake(Pickupable item)
	{
		//If item is correct type
		if (IsAcceptableItem(item.gameObject.tag))
		{
			//If slot is empty
			ItemPlace emptySlot = GetEmptySlot();
			if (emptySlot != null)
			{
				return PlaceInfo.Success("place in " + hoverName);
			}
			else
			{
				return PlaceInfo.Problem("No space.");
			}
		}
		else
		{
			return CantHoldTypeProblem(item);
		}
	}
	public override PlaceInfo WouldGive(Pickupable item)
	{
		if (item.canBePickUp)
		{
			return PlaceInfo.Success("pickup " + item.name);
		}
		else
		{
			return PlaceInfo.Problem(item.cantPickUpReason);
		}
	}
	public override void Take(Pickupable item, Vector3 place)
	{
		item.transform.SetParent(itemParent);

		ItemPlace emptySlot = GetEmptySlot();

		emptySlot.item = item;

		item.transform.position = emptySlot.place.position;
		item.transform.localRotation = Quaternion.identity;
	}
	public override void Give(Pickupable item)
	{
		ItemPlace currentSlot = GetItemSlot(item);
		currentSlot.item = null;
	}


	private void Start()
	{
		items = new ItemPlace[places.Length];
		for (int i = 0; i < items.Length; i++)
		{
			items[i] = new ItemPlace();
			items[i].item = null;
			items[i].place = places[i];
		}
	}
	private ItemPlace GetEmptySlot()
	{
		foreach (ItemPlace slot in items)
		{
			if (slot.item == null)
			{
				return slot;
			}
		}
		return null;
	}
	private ItemPlace GetItemSlot(Pickupable item)
	{
		foreach (ItemPlace slot in items)
		{
			if (slot.item == item)
			{
				return slot;
			}
		}
		return null;
	}
	private PlaceInfo CantHoldTypeProblem(Pickupable item)
	{
		//add item name
		string problem = item.gameObject.tag;

		//add midsection
		problem += " can only hold ";
		//add acceptable itms
		for (int i = 0; i < acceptableItems.Length; i++)
		{
			problem += acceptableItems[i];

			if (i < acceptableItems.Length - 1)
			{
				if (i < acceptableItems.Length - 2)
				{
					problem += ", ";
				}
				else
				{
					problem += " and ";
				}
			}
		}

		problem += ".";

		return PlaceInfo.Problem(problem);
	}
	private bool IsAcceptableItem(string itemTag)
	{
		foreach (string acceptable in acceptableItems)
		{
			if (itemTag == acceptable)
			{
				return true;
			}
		}
		return false;
	}
}
