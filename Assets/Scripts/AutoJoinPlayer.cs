using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager))]
public class AutoJoinPlayer : MonoBehaviour
{
	public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
		Debug.Log(PlayerInput.Instantiate(playerPrefab,0,null,0, InputSystem.devices[0]));
	}
	void OnPlayerJoined(PlayerInput player)
	{
		
	}
}
