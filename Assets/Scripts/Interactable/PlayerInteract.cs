using UnityEngine;

[RequireComponent(typeof(PlayerTool))]
[RequireComponent(typeof(PlayerSense))]
[RequireComponent(typeof(UserInput))]

public class PlayerInteract : MonoBehaviour
{
    public PlayerUI interactionUI;

	//private vars
    private InputManager input;
    private PlayerSense sensor;
    private PlayerTool tool;
    private Interactable interactableHover;

	// Start is called before the first frame update
	void Start()
	{
        //get ui from current PlayerJoin
        interactionUI = PlayerJoin.interactionUI;
        
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
		if(interactableHover == null) return;
		//check if interactable will interact with player
        InteractionInfo response = interactableHover.WouldInteract(this);
        if(response.type == InteractionType.Success)
        {
            //yes
            interactableHover.Interact(this);
        }
        else if(response.type == InteractionType.Problem)
        {
            //no
            interactionUI.Problem(response.message);
        }
        else //response.type == InteractionType.None (it isn't meant to interact with player, just tool)
        {
            //check if will interact with current holding item
            response = interactableHover.WouldInteract(tool.toolInteractable);
            if(response.type == InteractionType.Success)
            {
                //yes
                interactableHover.Interact(tool.toolInteractable);
            }
            else if(response.type == InteractionType.Problem)
            {
                //no
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
            //IS NOT LOOKING AT AN INTERACTABLE
            NoHover();
        }
	}
	private void HoverItem(Interactable interactable)
	{
        if(interactableHover != interactable)
		{
            interactableHover = interactable;
		    interactionUI.ShowInfo(interactable);
            ShowPossibleInteraction();
        }
	}
	private void NoHover()
	{
		interactableHover = null;
		interactionUI.HideInfo();
		interactionUI.HideInteraction();
	}
	private void ShowPossibleInteraction()
	{
		InteractionInfo response = interactableHover.WouldInteract(this);
        if(response.type == InteractionType.Success)
        {
            //yes
            interactionUI.ShowInteraction(response.message);
        }
        else if(response.type == InteractionType.Problem)
        {
            //no
            interactionUI.HideInteraction();
        }
        else //response.type == InteractionType.None (it isn't meant to interact with player, just tool)
        {
            //check if will interact with current holding item
            response = interactableHover.WouldInteract(tool.toolInteractable);
            if(response.type == InteractionType.Success)
            {
                //yes
                interactionUI.ShowInteraction(response.message);
            }
            else if(response.type == InteractionType.Problem)
            {
                //no
                interactionUI.Problem(response.message);
            }
        }
	}
	
}
