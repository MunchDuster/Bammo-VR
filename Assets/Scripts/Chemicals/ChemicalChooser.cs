using UnityEngine;

public class ChemicalChooser : MonoBehaviour
{
	[SerializeField]
	private Chemical[] possibleChoices;

	// Start is called before the first frame update
	void Start()
	{
		GameSettings.current.unknownChemical = possibleChoices[Random.Range(0, possibleChoices.Length - 1)];
		Debug.Log("Mystery chemical is: " + GameSettings.current.unknownChemical);
	}
}
