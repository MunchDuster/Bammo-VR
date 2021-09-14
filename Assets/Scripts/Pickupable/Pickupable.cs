using UnityEngine;

public class Pickupable : MonoBehaviour
{
    [SerializeField]
    private bool canBePickUp = true;
    [SerializeField]
    private string cantPickUpReason = "Reason can't pick up.";
    
    public PlaceInfo CanBePickedUp()
    {
       if(canBePickUp)
        {
            return PlaceInfo.Success;
        }
        else
        {
            return PlaceInfo.Problem(cantPickUpReason);
        }
    }
}
