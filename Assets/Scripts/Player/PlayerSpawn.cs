using UnityEngine;


/*
This sccript handles the player spawning.
It takes all the references that alll the other scripts on the player will need and hands them out.
*/
public class PlayerSpawn : MonoBehaviour
{
	public void Spawn(PlayerUI ui)
	{
		GetComponent<PlayerPickup>().interactionUI = ui;
		GetComponent<PlayerInteract>().interactionUI = ui;
	}
}
