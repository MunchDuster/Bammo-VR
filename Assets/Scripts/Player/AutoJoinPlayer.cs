using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager))]
public class AutoJoinPlayer : MonoBehaviour
{
	public GameObject playerPrefab;

	public PlayerUI interactionUI;

    // Start is called before the first frame update
    void Start()
    {
		PlayerInput player = PlayerInput.Instantiate(playerPrefab,0,null,0, InputSystem.devices[0]);
		
        player.gameObject.GetComponent<PlayerInteract>().interactionUI = interactionUI;
        player.gameObject.GetComponent<PlayerPickup>().interactionUI = interactionUI;
	}
}
