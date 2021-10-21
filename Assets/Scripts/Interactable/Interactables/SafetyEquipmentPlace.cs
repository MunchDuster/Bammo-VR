using UnityEngine;

public class SafetyEquipmentPlace : Interactable
{
	[SerializeField]
	private Criteria[] equipmentMustBeWornCriteria;

	private Criteria notWearingCriteria;
	public override void Interact(PlayerInteract player)
	{
		Debug.Log("Interacting with player.");
		notWearingCriteria.hasBeenMet = true;


	}
	public override InteractionInfo WouldInteract(PlayerInteract player)
	{
		foreach (Criteria criteria in equipmentMustBeWornCriteria)
		{
			if (criteria.hasBeenMet)
			{
				return InteractionInfo.Success("");
			}
		}
		return InteractionInfo.Problem("Can't place safety equipment that you are not wearing.");
	}
}