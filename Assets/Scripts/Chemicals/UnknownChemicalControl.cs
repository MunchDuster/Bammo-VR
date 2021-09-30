using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ChemicalContainer))]
public class UnknownChemicalControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndGet());
    }
    IEnumerator WaitAndGet()
    {
        yield return new WaitForSeconds(1);
        GetComponent<ChemicalContainer>().contents = GameSettings.current.unknownChemical;
		Debug.Log("Mystrey s " + GameSettings.current.unknownChemical);
    }
}
