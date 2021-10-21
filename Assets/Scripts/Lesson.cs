using UnityEngine;
using UnityEngine.UI;

public class Lesson : MonoBehaviour
{
	[SerializeField]
	private GameObject lockedCover;
	[SerializeField]
	private Text lessonNameText;
	[SerializeField]
	private Button button;

	[HideInInspector]
	public string lessonName;
	[HideInInspector]
	public int lessonNumber;

	private void Start()
	{
		lessonNumber = transform.GetSiblingIndex();

		GameSettings.current.OnLevelNoChanged += updateLocked;
		updateLocked(GameSettings.current.levelNo);
	}
	private void OnDestroy()
	{
		GameSettings.current.OnLevelNoChanged -= updateLocked;
	}
	private void updateLocked(int curLevel)
	{
		if (lessonNumber <= curLevel)
		{
			lockedCover.SetActive(false);
			button.enabled = true;
		}
		else
		{
			lockedCover.SetActive(true);
			button.enabled = false;
		}
	}
	public void SetLesson()
	{
		GameSettings.current.currentLevel = lessonNumber;
	}
}
