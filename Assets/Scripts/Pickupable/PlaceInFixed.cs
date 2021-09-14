using UnityEngine;

public class PlaceInFixed : Placeable
{
    [SerializeField]
    private Transform[] places;
    [SerializeField]
    private Transform itemParent;

	public string[] acceptableItems;
    
    
    private class ItemPlace
    {
        public Pickupable item;
        public Transform place;
    }
    private ItemPlace[] items;
    
    private void Start() 
    {
		Debug.Log("ENGTH" + acceptableItems.Length);
        items = new ItemPlace[places.Length];
        for(int i =0; i < items.Length; i++)
        {
            items[i] = new ItemPlace();
            items[i].item = null;
            items[i].place = places[i];
        }
    }
    private ItemPlace GetEmptySlot()
    {
        foreach(ItemPlace slot in items)
        {
            if(slot.item == null)
            {
                return slot;
            }
        }
        return null;
    }
    private ItemPlace GetItemSlot(Pickupable item)
    {
        foreach(ItemPlace slot in items)
        {
            if(slot.item == item)
            {
                return slot;
            }
        }
        return null;
    }
	private PlaceInfo CantHoldTypeProblem(Pickupable item)
	{
		//add item name
		string problem = item.gameObject.GetComponent<Interactable>().GetType().Name;	

		//add midsection
		problem += " can only hold ";
		//add acceptable itms
		Debug.Log("LENGTH: " + acceptableItems.Length);
		for(int i = 0; i < acceptableItems.Length; i++)
		{
			problem += acceptableItems[i];
			 
			if(i < acceptableItems.Length - 1)
			{
				if(i < acceptableItems.Length - 2)
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
	private bool IsAcceptableItem(Interactable item)
	{
		string itemName = item.GetType().Name;
		Debug.Log("LENGTH: " + acceptableItems.Length);
		foreach(string acceptable in acceptableItems)
		{
			Debug.Log("ITEM TYPE NAME: " + itemName + ", COMPARED TO: " + acceptable);
			if(itemName == acceptable)
			{
				return true;
			}
		}
		return false;
	}

    
    public override PlaceInfo WouldTake(Pickupable item)
    {
        //If item is correct type
        Interactable interactable = item.gameObject.GetComponent<Interactable>();
        
		if(IsAcceptableItem(interactable))
		{
			//If slot is empty
        	ItemPlace emptySlot = GetEmptySlot();
			if(emptySlot != null)
			{
				return PlaceInfo.Success;
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
        return item.CanBePickedUp();
    }
    public override void Take(Pickupable item)
    {
        item.transform.SetParent(itemParent);
        
        ItemPlace emptySlot = GetEmptySlot();
        
        emptySlot.item = item;
        
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
    }
    public override void Give(Pickupable item, Transform newParent)
    {
        item.transform.SetParent(newParent);
        
        ItemPlace currentSlot = GetEmptySlot();
        
        currentSlot.item = null;
        
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
    }
}
