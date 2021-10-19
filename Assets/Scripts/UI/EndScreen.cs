using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
	public TextMeshProUGUI text;
	private void Awake()
	{
		{
			float time = Time.time;

			text.text = "Time taken: " + (time) + "s.";

			//Update level no if need be
			if (GameSettings.current.currentLevel == GameSettings.current.levelNo)
			{
				GameSettings.current.levelNo++;
				Debug.Log(GameSettings.current.levelNo);
			}
		}
	}
}
