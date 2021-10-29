using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestSizeSceneGetter : MonoBehaviour
{    
    // Start is called before the first frame update
    private void Start()
    {
		float textMultiplier = GameSettings.current.textSize;
		UpdateText(textMultiplier);
        
        GameSettings.current.OnTextSizeChanged += UpdateText;
	}
    private void OnDestroy() 
    {
		GameSettings.current.OnTextSizeChanged -= UpdateText;
    }

	float lastValue = 1;
    
	// Update is called once per frame
	private void UpdateText(float size)
    {
		Debug.Log("Resizing" + size);
		Text[] texts = GameObject.FindObjectsOfType<Text>();
		TextMeshProUGUI[] textMeshProText = GameObject.FindObjectsOfType<TextMeshProUGUI>();

		float deltaSize = size / lastValue;


		foreach (Text text in texts)
		{
			text.fontSize = (int)(text.fontSize * deltaSize);
		}
		foreach (TextMeshProUGUI text in textMeshProText)
		{
			text.fontSize = (int)(text.fontSize * deltaSize);
		}

		lastValue = size;
    }
}
