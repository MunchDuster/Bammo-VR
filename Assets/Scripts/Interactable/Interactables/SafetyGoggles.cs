using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyGoggles : Interactable
{
	[SerializeField]
	private Transform headOffset;
	[SerializeField]
	private Criteria criteriaMetWhenWearing;


    public override void Interact(PlayerInteract player)
    {
        Debug.Log("Putting on glasses...");

		//Get the player's head transform
		Transform head = player.gameObject.GetComponent<PlayerMovement>().head;

		//Set the parent of the goggles to the head transform
		transform.SetParent(head);

		//Set layer mask to ignore raycast so that the player can raycast through the goggles (also hides mesh from player camera)
		gameObject.layer = 9;


		//Set offset and stuff
		transform.localPosition = headOffset.localPosition;
		transform.localRotation = headOffset.localRotation;

		//Set criteria met
		criteriaMetWhenWearing.hasBeenMet = true;

	
    }
	public override InteractionInfo WouldInteract(PlayerInteract player)
    {
        return InteractionInfo.Success;
    }
}
