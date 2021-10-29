using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerText : MonoBehaviour
{
	public Toggle toggle;
	public TMP_InputField text;

	public string offText;
    public string onText;

	private void Start() 
    {
        toggle.onValueChanged.AddListener(
			delegate { toggleChanged(toggle.isOn); }
        );
    }
    private void OnDestroy() {
		toggle.onValueChanged.RemoveListener(
			delegate { toggleChanged(toggle.isOn); }
        );
	}
	
	private void toggleChanged(bool value)
    {
		string oldtext = text.text;
		text.text = value ? oldtext + onText : oldtext + offText;

		text.MoveToEndOfLine(false, true);
		Debug.Log(text.text);
    }
}
