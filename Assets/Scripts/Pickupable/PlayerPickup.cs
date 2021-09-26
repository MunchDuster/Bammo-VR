using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerTool))]
[RequireComponent(typeof(PlayerSense))]
[RequireComponent(typeof(UserInput))]
public class PlayerPickup : MonoBehaviour
{
    public PlayerUI interactionUI;
    
	
    [SerializeField]
	private Transform itemParent;
    
    public UnityEvent OnPickup;
	public UnityEvent OnPlace;
	public UnityEvent OnHoverStart;
	public UnityEvent OnHoverEnd;

    private InputManager input;
    private PlayerSense sensor;
    private PlayerTool tool;
    
    
    private Placeable placeableHover;
    private Pickupable pickupableHover;
	private bool colliderWasTrigger;
    
    void Start()
    {        
        //get components from gameobject
        sensor = GetComponent<PlayerSense>();
        input = GetComponent<UserInput>();
        tool = GetComponent<PlayerTool>();
        
		//assign functions to delegates
		input.OnPickupPressed += OnPickupPressed;
    }
    // Called on late update in 
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
                    //hover object is placeable and player is holding item
                    placeableHover = placeable;
                    interactionUI.ShowPickupable(true);
                }
                else
                {
                    //hover object is not placeable
                    placeableHover = null;
                }
            }
            else
            {
				//Cant place if not holding anything
                placeableHover = null;
            }
            
            Pickupable pickupable = sensor.hoverObject.GetComponent<Pickupable>();
            if (pickupable != null)
            {
                //IS LOOKING AT A PICKUPABLE
                pickupableHover = pickupable;

                //TELL USER IF NOT ALREADY SHOWING PLACEABLE
                if(placeableHover == null)
                {
                    interactionUI.ShowPickupable(false);
                }
            }
            else
            {
                //Hover object cdoes not have pickupable
                pickupableHover = null;
		    }
        }
		else
		{
			//Is not hovering object at all
			placeableHover = null;
		}
        
        if(placeableHover == null && pickupableHover == null)
        {
            interactionUI.HidePickupable();
        }
	}

	//Place current tool
    private void Place()
	{
		OnPlace.Invoke();

        Pickupable pickup = tool.toolPickupable;
        
		placeableHover.Take(pickup, sensor.hoverPoint);
        tool.SetNull();
	}

    //Pickup an item
	private void Pickup(Pickupable item)
	{
		OnPickup.Invoke();
		item.transform.SetParent(itemParent);

		item.transform.localPosition = Vector3.zero;
		item.transform.localRotation = Quaternion.identity;
		
		tool.SetFromPickupable(item);
		
		Rigidbody rb = item.GetComponent<Rigidbody>();
		if(rb != null)
		{
			rb.isKinematic = true;
            item.GetComponent<Collider>().isTrigger = true;
		}

		//Make sure the collider does not have collision
		Collider col = item.GetComponent<Collider>();
		if(col.isTrigger)
		{
			colliderWasTrigger = true;
		}
		else
		{
			colliderWasTrigger = false;
			col.isTrigger = true;
		}
	}
    void OnPickupPressed()
	{
		//if player can place an item then try placing, if not,check if player can pick up an item
		if(tool.curTool != null)
        {
             if(placeableHover != null)
            {
                if(canPlace())
                {
					//reset the collider
					if(!colliderWasTrigger)
					{
						Collider col = tool.curTool.gameObject.GetComponent<Collider>();
						col.isTrigger = false;
					}
                    Place();
                }	
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
		if(tool.curTool == null || placeableHover == null ) return false;

			
		PlaceInfo info = placeableHover.WouldTake(tool.toolPickupable);
			
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
	
    void OnDestroy()
	{
		//remove functions from delegates
		input.OnPickupPressed -= OnPickupPressed;
	}
};