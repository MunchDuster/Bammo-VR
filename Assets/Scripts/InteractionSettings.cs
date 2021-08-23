using UnityEngine;

[CreateAssetMenu(fileName = "InteractableSettings", menuName = "Interactable/InteractableSettings", order = 0)]
public class InteractionSettings : ScriptableObject
{
	public string name;
	public string hoverInfo;

	public bool pickupable;
}
