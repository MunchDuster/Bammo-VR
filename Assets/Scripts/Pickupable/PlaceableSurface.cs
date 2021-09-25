using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableSurface : Placeable
{
    [SerializeField]
    private Transform itemParent;
    
    public override PlaceInfo WouldTake(Pickupable item)
    {
        return PlaceInfo.Success;
    }
    public override PlaceInfo WouldGive(Pickupable item)
    {
        return PlaceInfo.Success;
    }
    
    public override void Take(Pickupable item, Vector3 place)
    {
        item.transform.SetParent(itemParent);
        
        
        Rigidbody rb = item.GetComponent<Rigidbody>();
		if(rb != null)
		{
			rb.isKinematic = false;
            item.GetComponent<Collider>().isTrigger = false;
		}
        
        item.transform.rotation = GetPlacedRotation(item.transform.position);
		item.transform.position = place + item.bottom.localPosition + Vector3.up * 0.05f;
            
    }
    public override void Give(Pickupable item)
    {
        //Nothing to do.
    }

	private Quaternion GetPlacedRotation(Vector3 position)
	{
		Vector3 offset = transform.position - position;
		Vector3 forward = transform.forward;

		float cosAngle = Vector3.Dot(Vector3.Scale(offset, new Vector3(1,0,1)), Vector3.Scale(forward, new Vector3(1,0,1)) );

		float angle = Mathf.Acos(cosAngle) * Mathf.Rad2Deg;
		Debug.Log(angle);

		return Quaternion.Euler(0, angle, 0);
	}
    
}
