using UnityEngine;
using UnityEngine.UI;

public class Lesson : MonoBehaviour
{
	[SerializeField]
	private GameObject lockedCover;
	[SerializeField]
	private Text lessonNameText;

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
	private void updateLocked(int curLevel)
	{
		if (lessonNumber <= curLevel)
		{
			lockedCover.SetActive(false);
		}
		else
		{
			lockedCover.SetActive(true);
		}
	}
}
