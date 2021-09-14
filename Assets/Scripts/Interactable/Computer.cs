using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Interactable
{
    public override void Interact(PlayerInteract player)
    {
        Debug.Log("Computer interacting with player.");
    }
    
    
	public override InteractionInfo WouldInteract(PlayerInteract player)
    {
        return InteractionInfo.Success;
    }
}
