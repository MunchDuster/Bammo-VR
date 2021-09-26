using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SubmissionPanel : MonoBehaviour
{
    [SerializeField]
    
    public TMP_InputField inputField; 
    public UnityEvent OnCorrectSubmission;
    public UnityEvent OnWrongSubmission; 
    
    public void ShowSubmitPanel() 
    {
        if(inputField.text == GameSettings.current.unknownChemical.symbol)
        {
            OnCorrectSubmission.Invoke();
        }
        else
        {
            OnWrongSubmission.Invoke();
        }
    }
}
