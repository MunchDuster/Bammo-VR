using UnityEngine;
using UnityEngine.UI;

public class ShowInteract : MonoBehaviour
{
	[Header("Texts")]
	public Text itemName;
	public Text infoText;

	public Text interactText;
	
	[Header("Parents")]
	public GameObject allParent;
	public GameObject pickupParent;
	public GameObject placeParent;

	public GameObject interactParent;

	public void ShowHover(Interactable interactable, bool place)
	{
		if(interactable == null) return;

		allParent.SetActive(true);

		itemName.text = interactable.itemName;
		infoText.text = interactable.hoverInfo;

		if(!place)
		{
			pickupParent.SetActive(true);
			placeParent.SetActive(false);
		}
		else
		{
			pickupParent.SetActive(false);
			placeParent.SetActive(true);
		}
	}
	public void HideHover()
	{
		pickupParent.SetActive(false);
			placeParent.SetActive(false);
	}
	public void ShowInteraction(string text)
	{
		interactText.text = text;
		interactParent.SetActive(true);
	}
	public void HideInteraction()
	{
		interactParent.SetActive(false);
	}
}
