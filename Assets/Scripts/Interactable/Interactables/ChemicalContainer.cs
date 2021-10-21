using UnityEngine;

public class ChemicalContainer : Interactable
{
	public Chemical contents;

	public override void Interact(Interactable other)
	{
		(other as TestTube).contents = contents;
	}
	public override InteractionInfo WouldInteract(Interactable other)
	{
		if (other == null) return InteractionInfo.None;

		Debug.Log("PASSED CHECK");
		if (other.GetType().Name == "TestTube")
		{
			return InteractionInfo.Success("pour into test tube.");
		}
		else
		{
			return InteractionInfo.Problem("Can only interact with a TestTube");
		}
	}
}