using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : Interactable
{
    public delegate void OnPlayerPassEvent();
    public OnPlayerPassEvent OnPlayerPassThrough;
    
    [SerializeField]
    private Renderer canPassLight;
    
    public Criteria[] criterias = new Criteria[0];
    private Transform player;
    private Animator animator;
        
    private bool isOpen = false;
    
    public override InteractionInfo WouldInteract(PlayerInteract player)
    {
        foreach(Criteria criteria in criterias)
        {
            if(!criteria.hasBeenMet)
            {
				Debug.Log("wont open door because: " + criteria.meetRequirement);

                return InteractionInfo.Problem(criteria.meetRequirement);
            }
        }
		Debug.Log("Opening Door");
        return InteractionInfo.Success;
    }
    public override void Interact(PlayerInteract player)
    {
		isOpen = !isOpen;
        animator.SetBool("IsOpen",isOpen);
        StartCoroutine(WaitForPlayerToPassThrough());
    }
    
    private void Start() 
    {
        animator = GetComponent<Animator>();
        
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
		Debug.Log("Player Set");
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
            canPassLight.material.SetColor("_EmissionColor", Color.green);
        }
        else
        {
            canPassLight.material.SetColor("_EmissionColor", Color.red);
        }
    }
}
