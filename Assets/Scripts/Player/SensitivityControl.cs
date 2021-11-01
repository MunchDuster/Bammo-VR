using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class SensitivityControl : MonoBehaviour
{
	private PlayerMovement movement;

	// Start is called before the first frame update
	void Start()
	{
		//get the movement
		movement = GetComponent<PlayerMovement>();
		//add listeer
		GameSettings.current.OnSensitivityChanged += OnSensitivityChanged;
	}
	// OnDestroy is called just before the gameObejct is destroyed
	private void OnDestroy()
	{
		//remove the listener
		GameSettings.current.OnSensitivityChanged -= OnSensitivityChanged;
	}
	// Listens for change in sensitivity in settings
	void OnSensitivityChanged(float value)
	{
		//set the player sensitivity
		movement.turnSensitivity = value * 9 + 1;
	}
}
