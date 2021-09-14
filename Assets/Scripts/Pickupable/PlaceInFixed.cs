using UnityEngine;

public class PlaceInFixed : Placeable
{
    [SerializeField]
    private Transform[] places;
    [SerializeField]
    private Transform itemParent;
    
    
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
    
    public override PlaceInfo WouldTake(Pickupable item)
    {
        //If item is correct type
        Interactable interactable = item.gameObject.GetComponent<Interactable>();
        Debug.Log("ITEM TYPE NAME: " + interactable.GetType().Name);
        //If slot is empty
        ItemPlace emptySlot = GetEmptySlot();
        
        return PlaceInfo.Problem("Because I dont want to.");
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
