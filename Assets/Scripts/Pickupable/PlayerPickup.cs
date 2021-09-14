using UnityEngine;


[RequireComponent(typeof(PlayerTool))]
[RequireComponent(typeof(PlayerSense))]
[RequireComponent(typeof(UserInput))]
public class PlayerPickup : MonoBehaviour
{
    public ShowInteract interactionUI;
    
    [SerializeField]
	private Transform itemParent;
    
    
    private InputManager input;
    private PlayerSense sensor;
    private PlayerTool tool;
    
    
    private Placeable placeableHover;
    private Pickupable pickupableHover;
    
    void Start()
    {
        //get components from gameobject
        sensor = GetComponent<PlayerSense>();
        input = GetComponent<UserInput>();
        tool = GetComponent<PlayerTool>();
        
		//assign functions to delegates
		input.OnPickupPressed += OnPickupPressed;
    }
    // Update is called once per frame
	void LateUpdate()
	{
		//Pickupable HOVER UPDATE
		if(sensor.hoverObject != null)
        {
            if(tool.curTool != null)
            {
                Placeable placeable = sensor.hoverObject.GetComponent<Placeable>();
                if (placeable != null)
                {
                    //IS LOOKING AT A PLACEABLE
                    placeableHover = placeable;
                    interactionUI.ShowPickupable(true);
                }
                else
                {
                    //IS NOT LOOKING AT A PLACEABLE
                    placeableHover = null;
                    NoHover();
                }
            }
            else
            {
                placeableHover = null;
            }
            
            Pickupable pickupable = sensor.hoverObject.GetComponent<Pickupable>();
            if (pickupable != null)
            {
                //IS LOOKING AT A PICKUPABLE
                pickupableHover = pickupable;
                interactionUI.ShowPickupable(false);
            }
            else
            {
                //IS NOT LOOKING AT A PICKUPABLE
                pickupableHover = null;
                NoHover();
		    }
            
            
        }
	}
    private void Place()
	{
        Pickupable pickup = tool.curTool.gameObject.GetComponent<Pickupable>();
        
		PlaceInfo info = placeableHover.WouldTake(pickup);
		if(info.type != PlacementType.Success)
		{
            placeableHover.Take(pickup);
            tool.curTool = null;
		}
		
	}
    //Pickup an item
	private void Pickup(Pickupable item)
	{
		Debug.Log("PICKUP");
		item.transform.SetParent(itemParent);
		item.transform.localPosition = Vector3.zero;
		tool.SetFromPickupable(item);
	}
    void OnPickupPressed()
	{
		//if player can place an item then try placing, if not,check if player can pick up an item
		if(tool.curTool != null && placeableHover != null)
		{
			if(canPlace())
			{
				Place();
			}	
		}
		else
		{
            if(pickupableHover == null) return;
			Pickup(pickupableHover);
		}
		
	}
    
	private bool canPlace()
	{
		if(tool.curTool == null) return false;
        PlaceInfo info = placeableHover.WouldTake(tool.curTool.gameObject.GetComponent<Pickupable>());
        
        if(info.type == PlacementType.Success)
        {
            return true;
        }
        else if(info.type == PlacementType.Problem)
        {
            interactionUI.Problem(info.message);
            return false;
        }
		return false;
	}
	private void NoHover()
    {
        interactionUI.HidePickupable();
    }
    void OnDestroy()
	{
		//remove functions from delegates
		input.OnPickupPressed -= OnPickupPressed;
	}
}