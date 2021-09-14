 using UnityEngine;

public class PlayerTool : MonoBehaviour
{
    //Hide public variables not to be editted 
    [HideInInspector]
	public Interactable curTool;
    public void SetFromPickupable(Pickupable pick)
    {
        curTool = pick.gameObject.GetComponent<Interactable>();
    }
}