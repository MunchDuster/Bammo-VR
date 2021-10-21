using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SubmissionPanel : MonoBehaviour
{
    public TMP_InputField inputField; 
    public UnityEvent OnCorrectSubmission;
    public UnityEvent OnWrongSubmission; 
    
    public void ShowSubmitPanel() 
    {
        string answer = GameSettings.current.unknownChemical.symbol;
        Debug.Log("Unknown chemical is " + answer);
        if(inputField.text == answer)
        {
            OnCorrectSubmission.Invoke();
        }
        else
        {
            OnWrongSubmission.Invoke();
        }
    }
}
