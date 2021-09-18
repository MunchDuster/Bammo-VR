using System.Collections;
using UnityEngine;

[System.Serializable]
public class Criteria
{
    public bool hasBeenMet;
    public string meetRequirement;
}
    
[RequireComponent(typeof(Animator))]
public class Door : Interactable
{
    public delegate void OnPlayerPassEvent();
    public OnPlayerPassEvent OnPlayerPassThrough;
    
    [SerializeField]
    private Renderer canPassLight;
    
    private Criteria[] criterias = new Criteria[0];
    private Transform player;
    private Animator animator;
        
    private bool isOpen = false;
    
    public override InteractionInfo WouldInteract(PlayerInteract player)
    {
        foreach(Criteria criteria in criterias)
        {
            if(!criteria.hasBeenMet)
            {
                return InteractionInfo.Problem(criteria.meetRequirement);
            }
        }
        return InteractionInfo.Success;
    }
    public override void Interact(PlayerInteract player)
    {
        isOpen = !isOpen;
        StartCoroutine(WaitForPlayerToPassThrough());
    }
    
    private void Start() 
    {
        animator = GetComponent<Animator>();
        
        player = PlayerJoin.current.player.transform;
        UpdateLight();
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
                return true;
            }
        }
        return false;
    }
    private void UpdateLight()
    {
        bool criteriaMet = checkCriteria();
        animator.SetBool("IsOpen",criteriaMet);
        if(criteriaMet)
        {
            canPassLight.material.color = Color.green;
        }
        else
        {
            canPassLight.material.color = Color.red;
        }
    }
}
