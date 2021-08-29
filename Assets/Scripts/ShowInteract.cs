using UnityEngine;
using UnityEngine.UI;

public class ShowInteract : MonoBehaviour
{
	public GameObject textParent;
	public Text mainText;
	public Text subText;

	public void HoverInteractable(Interactable interactable)
	{
		if(interactable == null) return;
		textParent.SetActive(true);
		mainText.text = interactable.itemName;
		subText.text = interactable.hoverInfo;
	}
	public void Hide()
	{
		textParent.SetActive(false);
	}
}
