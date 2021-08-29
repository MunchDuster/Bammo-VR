using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyTurn : MonoBehaviour
{
	//public vars
	public float speed = 10;
	public AnimationCurve smoothing = AnimationCurve.EaseInOut(0, 0, 1, 1);
	public float maxAngle = 45;
	public float minAngle = -45;

	//private vars
	private Vector3 intialEulers;
	private float lerpAmount;

    // Start is called before the first frame update
    void Start()
    {
        intialEulers = transform.localEulerAngles;
		lerpAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
		lerpAmount = (lerpAmount + Time.deltaTime * speed) % 1;

        Vector3 curEulers = Vector3.up * Mathf.Lerp(minAngle, maxAngle, smoothing.Evaluate(lerpAmount));

		transform.localRotation = Quaternion.Euler(curEulers);
    }
}
