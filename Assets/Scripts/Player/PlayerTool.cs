 using UnityEngine;

public class PlayerTool : MonoBehaviour
{
    //Hide public variables not to be editted 
    [HideInInspector]
	public GameObject curTool 
    {
        get{ return _curTool; }
    }
    public Interactable toolInteractable 
    {
        get {return _curToolInteractable; }
    }
    public Pickupable toolPickupable 
    {
        get {return _curToolPickupable; }
    }
    
    
    private GameObject _curTool;
    private Interactable _curToolInteractable;
    private Pickupable _curToolPickupable;
    
    public void SetFromPickupable(Pickupable pick)
    {
        _curTool = pick.gameObject;
        _curToolPickupable = _curTool.GetComponent<Pickupable>();
        _curToolInteractable = _curTool.GetComponent<Interactable>();
    }
    public void SetFromGameObject(GameObject obj)
    {
        _curTool = obj;
        _curToolInteractable = _curTool.GetComponent<Interactable>();
        _curToolPickupable = _curTool.GetComponent<Pickupable>();
    }
    public void SetNull()
    {
        _curTool = null;
        _curToolInteractable = null;
        _curToolPickupable = null;
    }
    
    
}