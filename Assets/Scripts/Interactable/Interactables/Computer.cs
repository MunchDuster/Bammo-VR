using UnityEngine;
using UnityEngine.Events;

public class Computer : Interactable
{
	[SerializeField]
	private Transform cameraPoint;

	public UnityEvent OnUserEnter;
	public UnityEvent OnUserExit;
	public UnityEvent OnSubmit;

	//Vars from player
	private PlayerInteract currentUser;
	private FollowTransform followTransform;
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	private Transform playerCamera;
	private PlayerMovement movement;


	public override void Interact(PlayerInteract player)
	{
		currentUser = player;

		//Move the player camera to the correct spot
		playerCamera = player.gameObject.GetComponent<PlayerSense>().cam.transform;

		originalPosition = cameraPoint.position;
		originalRotation = cameraPoint.rotation;

		playerCamera.position = cameraPoint.position;
		playerCamera.rotation = cameraPoint.rotation;

		//Disable the camera follow
		followTransform = playerCamera.gameObject.GetComponent<FollowTransform>();
		if (followTransform != null)
		{
			followTransform.enabled = false;
		}

		//Disable the player movement
		movement = player.gameObject.GetComponent<PlayerMovement>();
		movement.enabled = false;


		OnUserEnter.Invoke();
	}
	public override InteractionInfo WouldInteract(PlayerInteract player)
	{
		if (currentUser == null)
		{
			return InteractionInfo.Success("access computer");
		}
		else
		{
			return InteractionInfo.Problem("Someone is already using the computer.");
		}
	}


	public void OnExit()
	{
		//Throw error if no one is using it
		if (currentUser == null)
		{
			throw new System.Exception("Use exit called, no one is using computer.");
		}

		//No one is using the computer now
		currentUser = null;


		//put camera back
		playerCamera.localPosition = Vector3.zero;
		playerCamera.localRotation = Quaternion.identity;

		//Let FollowTransform take control of camera
		if (followTransform != null)
		{
			followTransform.enabled = true;
			followTransform = null;
		}

		//Enable player movement
		movement.enabled = true;
		movement = null;

		OnUserExit.Invoke();
	}

	public void Submit()
	{
		OnSubmit.Invoke();
	}

}
