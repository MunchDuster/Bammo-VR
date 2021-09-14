using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public string itemName;
	public string hoverInfo;
    
    
	public virtual void Interact(PlayerInteract player)
    {
        Debug.Log("Interacting with player.");
    }
    public virtual void Interact(Interactable other)
    {
        Debug.Log("Interacting with other.");
    }
    
    
	public virtual InteractionInfo WouldInteract(PlayerInteract player)
    {
        return InteractionInfo.None;
    }
    public virtual InteractionInfo WouldInteract(Interactable other)
    {
        return InteractionInfo.None;
    }
}
