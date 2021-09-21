using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UserInput))]
public class PlayerMovement : MonoBehaviour
{
	private InputManager input;
	private Rigidbody rb;

	public float moveSpeed = 10;
	public float turnSensitivity = 3;
	public Transform head;

	//private vars
	private Vector3 curEuler;

	// Start is called before the first frame update
	private void Start()
	{
		
        
        rb = GetComponent<Rigidbody>();
        input = GetComponent<UserInput>();
	}

	// Update is called once per frame
	private void Update()
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
		//LOOKING//

		//rotate head on x-axis (Up and down)
		float XturnAmount = input.look.y * Time.deltaTime * turnSensitivity;
		curEuler = Vector3.right * Mathf.Clamp( curEuler.x - XturnAmount, -90f, 90f);
		head.localRotation = Quaternion.Euler(curEuler);
		
		//rotate body on y-axis (Sideways)
		float YturnAmount = input.look.x * Time.deltaTime * turnSensitivity;
		transform.Rotate(Vector3.up * YturnAmount);
	}
	
	//Fixed Update is called once per physics loop
	void FixedUpdate()
	{
		//MOVEMENT//

		//get raw input
		Vector3 rawDirection = new Vector3(input.move.x, 0, input.move.y);

		//calculate force relactive to player forward
		Vector3 moveForce = transform.TransformDirection(rawDirection * moveSpeed);

		//remove force from y axis
		Vector3 applyForce = Vector3.Scale(moveForce - rb.velocity, new Vector3(1,0,1));

		//Apply to rigidbody
		rb.AddForce(applyForce, ForceMode.VelocityChange);
	}
}
