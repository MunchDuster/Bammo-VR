using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowInteract : MonoBehaviour
{
	[Header("Texts")]
	public Text itemName;
	public Text infoText;
	public Text interactText;
    public Text pickupText;
    public Text problemText;
	
	[Header("Parents")]
	public GameObject infoParent;
	public GameObject pickupParent;
	public GameObject placeParent;
	public GameObject interactParent;
    public GameObject problemParent;
    
	public void ShowInfo(Interactable interactable)
	{
		if(interactable == null) return;

		infoParent.SetActive(true);

		itemName.text = interactable.itemName;
		infoText.text = interactable.hoverInfo;
	}
    public void HideInfo()
	{
		infoParent.SetActive(false);
	}
    public void ShowPickupable(bool placeable)
    {
        if(placeable)
        {
            pickupText.text = "E to place";
        }
        else
        {
            pickupText.text = "E to pickup";
        }
        pickupParent.SetActive(true);
    }
	public void HidePickupable()
    {
        pickupParent.SetActive(false);
    }
	public void ShowInteraction(string interactionName)
	{
		interactText.text = interactionName;
		interactParent.SetActive(true);
	}
	public void HideInteraction()
	{
		interactParent.SetActive(false);
	}
    
    public void Problem(string problem)
    {
        problemText.text = problem;
        problemParent.SetActive(true);
        
        StartCoroutine(HideAfterXSeconds(problemParent,3));
    }
    private IEnumerator HideAfterXSeconds(GameObject obj, float secs)
    {
        yield return new WaitForSeconds(secs);
        obj.SetActive(false);
    }
}
