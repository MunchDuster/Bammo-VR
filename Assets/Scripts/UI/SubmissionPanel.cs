using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SubmissionPanel : MonoBehaviour
{
	public TextMeshProUGUI helpText;
	public TMP_InputField nameInput;
	public TMP_InputField chargeInput;

	public UnityEvent OnCorrectSubmission;
	public UnityEvent OnWrongSubmission;

	public void ShowSubmitPanel()
	{
		Chemical answer = GameSettings.current.unknownChemical;
		Debug.Log("Unknown chemical is " + answer);

		bool success = true;

		if (chargeInput.text != answer.charge)
		{
			success = false;
			helpText.text = "Wrong charge";
		}
		if (nameInput.text != answer.name)
		{
			success = false;
			helpText.text = "Wrong chemical";
		}

		if (success)
			if (OnCorrectSubmission != null) OnCorrectSubmission.Invoke();
			else
			if (OnWrongSubmission != null) OnWrongSubmission.Invoke();
	}
}
