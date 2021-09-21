using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class EnterChemicalFormula : MonoBehaviour 
{
    private TMP_InputField inputField;
    
    private void Start() 
    {
        inputField = GetComponent<TMP_InputField>();
        
        inputField.onValueChanged.AddListener(input => OnSomeValueEntered(input));
    }
    private void OnSomeValueEntered(string input)
    {
        Debug.Log(input);
    }
}