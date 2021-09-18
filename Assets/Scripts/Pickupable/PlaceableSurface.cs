using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableSurface : Placeable
{
    [SerializeField]
    private Transform itemParent;
    
    public override PlaceInfo WouldTake(Pickupable item)
    {
        Debug.Log("YES TABLE WOOD TAKE");
        return PlaceInfo.Success;
    }
    public override PlaceInfo WouldGive(Pickupable item)
    {
        return PlaceInfo.Success;
    }
    
    public override void Take(Pickupable item, Vector3 place)
    {
        Debug.Log("TAKE ITEM");
        
        item.transform.SetParent(itemParent);
        
        Rigidbody rb = item.GetComponent<Rigidbody>();
		if(rb != null)
		{
			rb.isKinematic = false;
            item.GetComponent<Collider>().isTrigger = false;
		}
        
        item.transform.rotation = Quaternion.identity;
		item.transform.position = place + item.bottom.localPosition + Vector3.up * 0.05f;
            
    }
    public override void Give(Pickupable item)
    {
        
    }
    
}
