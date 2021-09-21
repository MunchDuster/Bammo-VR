using UnityEngine;
using UnityEngine.Events;
using TMPro;

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
        Debug.Log("Computer interacting with player.");
        currentUser = player;
        
        //Move the player camera to the correct spot
        playerCamera = player.gameObject.GetComponent<PlayerSense>().cam.transform;
        
        originalPosition = cameraPoint.position;
        originalRotation = cameraPoint.rotation;
        
        playerCamera.position = cameraPoint.position;
        playerCamera.rotation = cameraPoint.rotation;
        
        //Disable the camera follow
        followTransform = playerCamera.gameObject.GetComponent<FollowTransform>();
        if(followTransform != null)
        {
            followTransform.enabled = false;
        }
        
        //Disable the player movement
        movement = player.gameObject.GetComponent<PlayerMovement>();
        movement.enabled = false;
        
        //Unlock the player cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        OnUserEnter.Invoke();
    }
    
    
	public override InteractionInfo WouldInteract(PlayerInteract player)
    {
        if(currentUser == null)
        {
            return InteractionInfo.Success;
        }
        else
        {
            return InteractionInfo.Problem("Someone is already using the computer.");
        }
    }
    
    
    public void OnExit()
    {
        //Throw error if no one is using it
        if(currentUser == null)
        {
            throw new System.Exception("Use exit called, no one is using computer.");
        }
        
        //No one is using the computer now
        currentUser = null;
        
        
        //put camera back
        playerCamera.position = originalPosition;
        playerCamera.rotation = originalRotation;
        
        //Let FollowTransform take control of camera
        if(followTransform != null)
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
        Debug.Log("Submitted");
        OnSubmit.Invoke();
    }
    
}
