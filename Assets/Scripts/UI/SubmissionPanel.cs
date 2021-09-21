using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SubmissionPanel : MonoBehaviour
{
    [SerializeField]
    private string[] correctAnswers;
    
    public TMP_InputField inputField; 
    public UnityEvent OnCorrectSubmission;
    public UnityEvent OnWrongSubmission; 
    
    public void ShowSubmitPanel() 
    {
        if(CheckResults())
        {
            OnCorrectSubmission.Invoke();
        }
        else
        {
            OnWrongSubmission.Invoke();
        }
    }
    
    private bool CheckResults()
    {
        foreach(string answer in correctAnswers)
        {
            Debug.Log(inputField.text + " compared to " + answer);
            if(inputField.text == answer)
            {
                return true;
            }
        }
        return false;
    }
}
