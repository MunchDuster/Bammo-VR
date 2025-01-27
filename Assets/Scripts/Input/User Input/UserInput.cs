﻿using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class UserInput : InputManager
{
	public void OnMove(InputValue value)
	{
		move = value.Get<Vector2>();
		if (OnMovePressed != null) OnMovePressed(move);
	}
	public void OnLook(InputValue value)
	{
		look = value.Get<Vector2>();
	}
	public void OnSettings(InputValue value)
	{
		settingsPressed = value.isPressed;
		if (OnSettingsPressed != null) OnSettingsPressed();
	}
	public void OnInteract(InputValue value)
	{
		interactPressed = value.isPressed;
		if (OnInteractPressed != null) OnInteractPressed();
	}
	public void OnPickup(InputValue value)
	{
		if (OnPickupPressed != null) OnPickupPressed();
	}
	public void OnZoom(InputValue value)
	{
		if (OnZoomPressed != null) OnZoomPressed();
	}
}
