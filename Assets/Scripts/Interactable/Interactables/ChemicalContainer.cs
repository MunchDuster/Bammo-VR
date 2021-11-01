using UnityEngine;

public class ChemicalContainer : Interactable
{
	public Chemical contents;

	public override void Interact(Interactable other)
	{
		TestTube testtube = other as TestTube;
		if (testtube.contents == null)
		{
			testtube.contents = contents;
		}
		else
		{
			Chemical newContents = testtube.contents.mix(contents);
			if (newContents == null) newContents = contents.mix(testtube.contents);

			testtube.contents = newContents;
		}
	}
	public override InteractionInfo WouldInteract(Interactable other)
	{
		if (other.GetType().Name == "TestTube")
		{
			TestTube testube = other as TestTube;
			if (testube.contents == null)
			{
				return InteractionInfo.Success("pour into test tube.");
			}
			else
			{
				return InteractionInfo.Success("mix in test tube.");
			}
		}
		else
		{

			return InteractionInfo.Problem("Can only interact with a TestTube");
		}
	}
}