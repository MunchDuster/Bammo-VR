public class Sink : Interactable
{
	public override InteractionInfo WouldInteract(Interactable other)
	{
		if (other.GetType() == typeof(TestTube))
		{
			return InteractionInfo.Success("empty test tube");
		}
		else
		{
			return InteractionInfo.Problem("Can only interactwith test tube.");
		}
	}

	public override void Interact(Interactable other)
	{
		TestTube testtube = other as TestTube;
		testtube.contents = null;
	}
}
