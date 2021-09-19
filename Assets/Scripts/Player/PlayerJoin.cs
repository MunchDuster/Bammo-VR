using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerJoin : MonoBehaviour
{
	[SerializeField]
	private Transform spawnPoint;
	public GameObject playerPrefab;

	public PlayerUI interactionUI;

    [HideInInspector]
    public GameObject player;
    
    public delegate void PlayerJoinedEvent(GameObject player);
    public static PlayerJoinedEvent OnPlayerJoined;

    // Start is called before the first frame update
    void Start()
    {
		PlayerInput playerInput = PlayerInput.Instantiate(playerPrefab,0,null,0, InputSystem.devices[0]);
		player = playerInput.gameObject;

		player.transform.position = spawnPoint.position;
		player.transform.rotation = spawnPoint.rotation;
        
		player.GetComponent<PlayerSpawn>().Spawn(interactionUI);
        if(OnPlayerJoined != null) OnPlayerJoined(player);
	}
}
