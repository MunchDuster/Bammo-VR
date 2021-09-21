using UnityEngine;


[RequireComponent(typeof(UserInput))]
public class PlayerSense : MonoBehaviour
{
    public Camera cam;
    
    
    [HideInInspector]
	public GameObject hoverObject;
    [HideInInspector]
    public Vector3 hoverPoint;
    
    private InputManager input;

	//private vars to be editted in inspector
	[SerializeField]
	private LayerMask mouseInteractLayerMask;
	[SerializeField]
    private float mouseRayMaxDistance = 1.5f;
	
    
    private void Start() 
    {
        input = GetComponent<UserInput>();
    }
    private void Update() 
    {
        Raycast();
        
    }
	private void Raycast()
	{
		Vector3 pos = Camera.main.transform.position;
		Vector3 dir = Camera.main.transform.forward;

		Ray ray = new Ray(pos,dir);
		if (Physics.Raycast(ray, out RaycastHit hit, mouseRayMaxDistance, mouseInteractLayerMask))
		{
			//Object hit
			Debug.DrawRay(pos,dir * hit.distance, Color.red);
            
            hoverPoint = hit.point;
			hoverObject = hit.transform.gameObject;
		}
		else
		{
			//No object hit
			Debug.DrawRay(pos,dir * mouseRayMaxDistance, Color.green);
            
            hoverPoint = pos + dir * mouseRayMaxDistance;
			hoverObject = null;
		}
	}
}