using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTube : Interactable
{
	public override InteractionInfo TakeItem(Interactable item)
	{
		return InteractionInfo.None;
	}
	public override bool CanHoldItem(Interactable item)
	{
		return false;
	}
	protected override string WouldInteractWithOther(Interactable other)
	{
		Debug.Log(typeof(Interactable));
		//if(other)
		return null;
	}
	protected override string WouldInteractWithPlayer(PlayerInteract player)
	{
		return null;
	}

    protected override InteractionInfo InteractWithOther(Interactable other)
	{
		//Nothing
		return InteractionInfo.None;
	}
	protected override InteractionInfo InteractWithPlayer(PlayerInteract player)
	{
		//Nothing
		return InteractionInfo.None;
	}
}
