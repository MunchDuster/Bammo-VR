using UnityEngine;

[RequireComponent(typeof(UserInput))]
public class PlayerZoom : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
	[SerializeField]
	private float zoomFOV = 10;

	private bool isZooming;
	private float oldFOV;
	private UserInput input;
    
    // Start is called before the first frame update
    private void Start() 
    {
        // Get the UserInput attached to gameobject
        input = GetComponent<UserInput>();
		// Subcribe OnZoomPressed to input
		input.OnZoomPressed += OnZoomPressed;
	}
    // OnDestroy is called just before the object is destroyed
    private void OnDestroy() 
    {
        // Unsubcribe OnZoomPressed from input
		input.OnZoomPressed -= OnZoomPressed;
    }
    // OnZoomPressed is subsribed to the UserInput OnZoom event
    private void OnZoomPressed()
    {
		isZooming = !isZooming;
        
		if(isZooming)
        {
            //Zoom
			oldFOV = cam.fieldOfView;
			cam.fieldOfView = zoomFOV;
		}
        else
        {
            //Unzoom
			cam.fieldOfView = oldFOV;
        }
	}
}
