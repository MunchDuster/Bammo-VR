using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : Interactable
{
    [SerializeField]
    private int indicatorMaterialIndex;
    [SerializeField]
    private Material indecatorMaterial;
    
    public delegate void OnPlayerPassEvent();
    public OnPlayerPassEvent OnPlayerPassThrough;
    public Criteria[] criterias;
	
	public UnityEvent OnOpen;
	public UnityEvent OnClose;
	public UnityEvent OnLock;
	public UnityEvent OnUnlock;
	public UnityEvent OnOpenFail;


    private Transform player;
    private Animator animator;    
    private Renderer renderer;
    private bool isOpen = false;
	private bool isLocked = true;


    
    public override InteractionInfo WouldInteract(PlayerInteract player)
    {
        foreach(Criteria criteria in criterias)
        {
            if(!criteria.hasBeenMet)
            {
				Debug.Log("wont open door because: " + criteria.meetRequirement);
				OnOpenFail.Invoke();
                return InteractionInfo.Problem(criteria.meetRequirement);
            }
        }
        return InteractionInfo.Success;
    }
    public override void Interact(PlayerInteract player)
    {
		isOpen = !isOpen;
        animator.SetBool("IsOpen",isOpen);

		if(isOpen)
		{
			OnOpen.Invoke();
		}
		else
		{
			OnClose.Invoke();
		}

        StartCoroutine(WaitForPlayerToPassThrough());
    }
    
    private void Start() 
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        
        PlayerJoin.OnPlayerJoined += OnPlayerJoined;

		OnPlayerPassThrough += UpdateLight;

		foreach(Criteria criteria in criterias)
		{
			criteria.OnCriteriaMet += UpdateLight;
		}
        UpdateLight();
    }
    private void OnPlayerJoined(GameObject newplayer)
	{
		// set player
		player = newplayer.transform;
		// Remove listener
		PlayerJoin.OnPlayerJoined -= OnPlayerJoined;
	}
    private IEnumerator WaitForPlayerToPassThrough()
    {
        float thisDot = Vector3.Dot(transform.forward, (player.position - player.position).normalized)
             ,lastDot = thisDot;
        
        //If the user passed throught from the front to the back or vice versa
        while((lastDot > 0 && thisDot < 0) || (lastDot < 0 && thisDot > 0))
        {
            yield return new WaitForEndOfFrame();
            
            lastDot = thisDot;
            thisDot = Vector3.Dot(transform.forward, (player.position - player.position).normalized);
        }
        
        OnPlayerPassThrough();
        UpdateLight();
    }
    private bool checkCriteria()
    {
        foreach(Criteria criteria in criterias)
        {
            if(!criteria.hasBeenMet)
            {
                return false;
            }
        }
        return true;
    }
    private void UpdateLight()
    {
        bool criteriaMet = checkCriteria();
        if(criteriaMet)
        {
			if(isLocked)
			{
				OnUnlock.Invoke();
				isLocked = false;
                
                SetIndicator(Color.green);
			}
        }
        else
        {
			if(!isLocked)
			{
				OnLock.Invoke();
				isLocked = true;
                
                SetIndicator(Color.red);
			}
        }
    }
    private void SetIndicator(Color color)
    {
        /*
        Material[] mats = renderer.materials;
                
        mats[indicatorMaterialIndex].color = color;
        
        renderer.materials = mats;
        */
        indecatorMaterial.color = color;
    }
}
