using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
	[HideInInspector]
	public Vector2 move;
	[HideInInspector]
	public Vector2 look;
	[HideInInspector]
	public Vector2 mousePosition;
	
	[HideInInspector]
	public bool interactPressed;
	[HideInInspector]
	public bool settingsPressed;
	

	public delegate void ButtonPressed(bool isPressed);
	public ButtonPressed OnInteractPressed;
	public ButtonPressed OnSettingsPressed;
}