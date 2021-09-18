using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerJoin : MonoBehaviour
{
    public static PlayerJoin current;
	public GameObject playerPrefab;

	public static PlayerUI interactionUI;

    [HideInInspector]
    public GameObject player;
    
    public delegate void PlayerJoinedEvent(GameObject player);
    public PlayerJoinedEvent OnPlayerJoined;
    
    private void Awake() 
    {
        if(current == null) current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
		PlayerInput playerInput = PlayerInput.Instantiate(playerPrefab,0,null,0, InputSystem.devices[0]);
		player = playerInput.gameObject;
        
        if(OnPlayerJoined != null) OnPlayerJoined(player);
	}
}
