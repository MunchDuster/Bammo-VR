using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class SensitivityControl : MonoBehaviour
{
	private PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
		movement = GetComponent<PlayerMovement>();
        GameSettings.current.OnSensitivityChanged += OnSensitivityChanged;
    }

    // Listens for change in sensitivity in settings
    void OnSensitivityChanged(float value)
    {
        movement.turnSensitivity = value * 9 + 1;
    }
}
