using UnityEngine;
using UnityEngine.UI;

public class ShowInteract : MonoBehaviour
{
	public GameObject textParent;
	public Text mainText;
	public Text subText;

	public void HoverInteractable(Interactable interactable)
	{
		textParent.SetActive(true);
		mainText.text = interactable.name;
		subText.text = interactable.hoverInfo;
	}
	public void Hide()
	{
		textParent.SetActive(false);
	}
}
