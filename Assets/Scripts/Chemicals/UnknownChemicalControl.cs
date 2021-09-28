using UnityEngine;

[RequireComponent(typeof(ChemicalContainer))]
public class UnknownChemicalControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ChemicalContainer>().contents = GameSettings.current.unknownChemical;
    }
}
