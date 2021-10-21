using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
	public float scrollSpeed = 1;
	public GameObject copyObject;

	private float curScroll;
	private RectTransform[] rects;

	//Start is called before update
	private void Start()
	{
		curScroll = 0;


		//create a copy of text below the current
		RectTransform newRect = Instantiate(copyObject, transform).GetComponent<RectTransform>();
		newRect.anchoredPosition += Vector2.up * newRect.sizeDelta.y;

		List<RectTransform> rectsList = new List<RectTransform>();
		foreach (Transform transform in transform)
		{
			rectsList.Add(transform.gameObject.GetComponent<RectTransform>());
		}
		rects = rectsList.ToArray();
	}
	// Update is called once per frame
	private void Update()
	{
		curScroll = (curScroll + Time.deltaTime * scrollSpeed);

		if (curScroll > rects[0].sizeDelta.y)
		{
			foreach (RectTransform rect in rects)
			{
				rect.anchoredPosition += Vector2.up * rect.sizeDelta.y;
			}
			curScroll = 0;
		}
		else
		{
			foreach (RectTransform rect in rects)
			{
				rect.anchoredPosition -= Vector2.up * Time.deltaTime * scrollSpeed;
			}
		}
	}
}
