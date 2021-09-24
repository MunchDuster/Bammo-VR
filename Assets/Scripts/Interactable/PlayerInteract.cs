using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerTool))]
[RequireComponent(typeof(PlayerSense))]
[RequireComponent(typeof(UserInput))]

public class PlayerInteract : MonoBehaviour
{
    public PlayerUI interactionUI;

	public UnityEvent OnInteractFail;
	//private vars
    private InputManager input;
    private PlayerSense sensor;
    private PlayerTool tool;
    private Interactable interactableHover;

	// Start is called before the first frame update
	void Start()
	{
        //get components from gameobject
        sensor = GetComponent<PlayerSense>();
        input = GetComponent<UserInput>();
        tool = GetComponent<PlayerTool>();
		//assign functions to delegates
		input.OnInteractPressed += OnInteractPressed;
	}
	void OnDestroy()
	{
		//remove functions from delegates
		input.OnInteractPressed -= OnInteractPressed;
	}

	void OnInteractPressed()
	{
        /*
        Priority Order:
        1. Interact with player
		2. Interact with player's tool
        */
        
		if(interactableHover == null) return;
		//Check if interactable will interact with player
        InteractionInfo response = interactableHover.WouldInteract(this);
        if(response.type == InteractionType.Success)
        {
            //yes
			Debug.Log("Interaction would happen");
            interactableHover.Interact(this);
        }
        else if(response.type == InteractionType.Problem)
        {
            //no
			Debug.Log("Interaction would not happen: " + response.message);
			OnInteractFail.Invoke();
            interactionUI.Problem(response.message);
        }
        else //response.type == InteractionType.None (it isn't meant to interact with player, just tool)
        {
            //check if holding an item
            if(tool.toolInteractable == null) return; 
            //check if  current holding item will interact with hover
            response = interactableHover.WouldInteract(tool.toolInteractable);
            if(response.type == InteractionType.Success)
            {
                //yes
                interactableHover.Interact(tool.toolInteractable);
            }
            else if(response.type == InteractionType.Problem)
            {
                //no
				OnInteractFail.Invoke();
                interactionUI.Problem(response.message);
            }
        }
        
	}

	// Update is called once per frame
	void LateUpdate()
	{
		//INTERACTABLE HOVER UPDATE
		GameObject hoverObject = sensor.hoverObject;
        if(hoverObject != null)
        {
            Interactable interactable = hoverObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                //IS LOOKING AT AN INTERACTABLE
                HoverItem(interactable);
            }
            else
            {
                //IS NOT LOOKING AT AN INTERACTABLE
                NoHover();
            }
        }
        else
        {
            //IS NOT LOOKING AT ANYTHING
            NoHover();
        }
	}
	private void HoverItem(Interactable interactable)
	{
        if(interactableHover != interactable)
		{
            interactableHover = interactable;
		    interactionUI.ShowInfo(interactable);
            interactionUI.ShowInteraction();
        }
	}
	private void NoHover()
	{
		interactableHover = null;
		interactionUI.HideInfo();
		interactionUI.HideInteraction();
	}
	
}
