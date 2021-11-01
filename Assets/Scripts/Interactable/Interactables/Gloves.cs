using UnityEngine;

public class Gloves : Interactable
{
	[SerializeField]
	private Transform lefthandOffset;
	[SerializeField]
	private Transform righthandOffset;
	[SerializeField]
	private Criteria criteriaMetWhenWearing;
	[SerializeField]
	private Transform leftglove;
	[SerializeField]
	private Transform rightglove;

	private Vector3 RHInitPosition, LHInitPosition;

	private void Start()
	{
		RHInitPosition = rightglove.position;
		LHInitPosition = leftglove.position;
	}
	public override void Interact(PlayerInteract player)
	{
		//////LEFT HAND///////
		//Get the player's head transform
		Transform head = player.gameObject.GetComponent<PlayerMovement>().lefthand;

		//Set the parent of the goggles to the head transform
		leftglove.SetParent(head);

		//Set layer mask to ignore raycast so that the player can raycast through the goggles (also hides mesh from player camera)
		gameObject.layer = 9;


		//Set offset and stuff
		leftglove.localPosition = lefthandOffset.localPosition;
		leftglove.localRotation = lefthandOffset.localRotation;

		//////RIGHT HAND///////
		/////Get the player's head transform
		head = player.gameObject.GetComponent<PlayerMovement>().righthand;

		//Set the parent of the goggles to the head transform
		rightglove.SetParent(head);

		//Set layer mask to ignore raycast so that the player can raycast through the goggles (also hides mesh from player camera)
		gameObject.layer = 9;


		//Set offset and stuff
		rightglove.localPosition = righthandOffset.localPosition;
		rightglove.localRotation = righthandOffset.localRotation;

		//Set criteria met
		criteriaMetWhenWearing.hasBeenMet = true;
	}
	public override InteractionInfo WouldInteract(PlayerInteract player)
	{
		return InteractionInfo.Success("put on gloves");
	}


	public void PutBack()
	{
		leftglove.SetParent(transform);
		rightglove.SetParent(transform);

		rightglove.position = RHInitPosition;
		leftglove.position = LHInitPosition;

		rightglove.localRotation = Quaternion.identity;
		leftglove.localRotation = Quaternion.identity;
	}
}
