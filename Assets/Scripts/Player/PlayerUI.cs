using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
	[Header("Settings")]
	public string pickupKey;
	public string interactKey;
	public float padding = 20;

	[Header("Texts")]
	public Text itemName;
	public Text infoText;
	public Text interactText;
	public Text pickupText;
	public Text problemText;

	[Header("Parents")]
	public GameObject infoParent;
	public GameObject pickupParent;
	public GameObject interactParent;
	public GameObject problemParent;

	private void Start()
	{
		HideInfo();
		HidePickupable();
		HideInteraction();
		problemParent.SetActive(false);
	}

	public void ShowInfo(Interactable interactable)
	{
		if (interactable == null) return;

		infoParent.SetActive(true);

		itemName.text = interactable.itemName;
		infoText.text = interactable.hoverInfo;
	}
	public void HideInfo()
	{
		infoParent.SetActive(false);
	}
	public void ShowPickupable(string message)
	{
		pickupParent.SetActive(true);
		pickupText.text = pickupKey + " to " + message;
	}
	public void HidePickupable()
	{
		pickupParent.SetActive(false);
	}
	public void ShowInteraction(string message)
	{
		interactParent.SetActive(true);
		interactText.text = interactKey + " to " + message;

		RectTransform rect = interactParent.GetComponent<RectTransform>();
		rect.sizeDelta = new Vector2(interactText.preferredWidth + padding, rect.sizeDelta.y);
	}
	public void HideInteraction()
	{
		interactParent.SetActive(false);
	}


	public void Problem(string problem)
	{
		problemText.text = problem;
		problemParent.SetActive(true);

		StartCoroutine(HideAfterXSeconds(problemParent, 3));
	}
	private IEnumerator HideAfterXSeconds(GameObject obj, float secs)
	{
		yield return new WaitForSeconds(secs);
		obj.SetActive(false);
	}
}
