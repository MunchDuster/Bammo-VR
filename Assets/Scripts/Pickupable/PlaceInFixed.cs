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
		foreach(string acceptable in acceptableItems)
		{
			Debug.Log("ITEM TYPE NAME: " + itemName + ", COMPARED TO: " + acceptable);
			if(itemName == acceptable)
			{
                Debug.Log("Item is  acceptable");
				return true;
			}
		}
		return false;
	}

    
    public override PlaceInfo WouldTake(Pickupable item)
    {
        //If item is correct type
        Interactable interactable = item.gameObject.GetComponent<Interactable>();
        if(interactable == null) return PlaceInfo.Problem("Cannot hold item.");
		if(IsAcceptableItem(interactable))
		{
			//If slot is empty
        	ItemPlace emptySlot = GetEmptySlot();
			if(emptySlot != null)
			{
                Debug.Log("Would take");
				return PlaceInfo.Success;
			}
			else
			{
                Debug.Log("NO SPACE");
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
    public override void Take(Pickupable item, Vector3 place)
    {
        Debug.Log("Taking");
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
}
