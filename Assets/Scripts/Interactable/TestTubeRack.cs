using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTubeRack : Interactable
{
	//vars
	[System.Serializable]
	private struct ItemPlace
	{
		public Transform itemPos;
		public 	Interactable item;
	}

	[SerializeField]
	private ItemPlace[] places;

	public override InteractionInfo TakeItem(Interactable item)
	{
		RefreshPlaces();
		int index = GetEmptyPlace();
		
		if(index != -1)
		{
			item.transform.SetParent(transform);
			item.transform.position = places[index].itemPos.position;
			places[index].item = item;
			
			Debug.Log("Placed");
			//Nothing
			return InteractionInfo.Success;
		}
		else
		{
			Debug.Log("Cant place");
			//No places
			return InteractionInfo.Problem("No places left");
		}
	}
	public override bool CanHoldItem(Interactable item)
	{
		Debug.Log(item.GetType());
		if(true)
		{
			return true;
		}
		return false;
	}
	//overrides
	protected override string WouldInteractWithOther(Interactable other)
	{
		Debug.Log(typeof(Interactable));
		//if(other)
		return null;
	}
	protected override string WouldInteractWithPlayer(PlayerInteract player)
	{
		return null;
	}
    protected override InteractionInfo InteractWithOther(Interactable other)
	{
		return InteractionInfo.None;

		
	}
	protected override InteractionInfo InteractWithPlayer(PlayerInteract player)
	{
		//Nothing
		return InteractionInfo.None;
	}

	//funcs used in overrides
	private bool IsNull(ItemPlace place)
	{
		return place.itemPos == null;
	}
	private int GetEmptyPlace()
	{
		for(int i=0;i<places.Length;i++)
		{
			if(places[i].item == null)
			{
				return i;
			}
		}
		return -1;
	}
	private void RefreshPlaces()
	{
		for(int i = 0; i < places.Length; i++)
		{
			ItemPlace place = places[i];
			if(place.item != null)
			{
				if(place.item.transform.parent != transform)
				{
					place.item = null;
				}
			}
		}
	}
}
