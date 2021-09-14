using UnityEngine;


[RequireComponent(typeof(UserInput))]
public class PlayerSense : MonoBehaviour
{
    [HideInInspector]
	public GameObject hoverObject;
    
    private InputManager input;

	//private vars to be editted in inspector
	[SerializeField]
	private LayerMask mouseInteractLayerMask;
	[SerializeField]
    private float mouseRayMaxDistance = 1.5f;
    [SerializeField]
	private Camera cam;
    
    private void Start() 
    {
        input = GetComponent<UserInput>();
    }
    private void Update() 
    {
        hoverObject = Raycast();
    }
	private GameObject Raycast()
	{
		Vector3 pos = Camera.main.transform.position;
		Vector3 dir = Camera.main.transform.forward;

		Ray ray = new Ray(pos,dir);
		if (Physics.Raycast(ray, out RaycastHit hit, mouseRayMaxDistance, mouseInteractLayerMask))
		{
			//Object hit
			Debug.DrawRay(pos,dir * hit.distance, Color.red);
			return hit.transform.gameObject;
		}
		else
		{
			//No object hit
			Debug.DrawRay(pos,dir * mouseRayMaxDistance, Color.green);
			return null;
		}
	}
}