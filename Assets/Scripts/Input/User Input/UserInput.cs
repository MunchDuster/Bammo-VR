using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UserInput : InputManager
{
	public void OnMove(InputValue value)
	{
		move = value.Get<Vector2>();
	}
	public void OnLook(InputValue value)
	{
		look = value.Get<Vector2>();
	}
	public void OnEscape(InputValue value)
	{
		settingsPressed = value.isPressed;
	}
	public void OnInteract(InputValue value)
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
