using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(UserInput))]
public class AnimatePlayer : MonoBehaviour
{
	private InputManager input;
	private Animator animator;

	private int forwardHash;
	private int sideHash;
	//Start is called before first update
	private void Start()
	{
		input = GetComponent<UserInput>();
		animator = GetComponent<Animator>();

		forwardHash = Animator.StringToHash("Forward");
		sideHash = Animator.StringToHash("Sideways");
	}
	// Update is called once per frame
	private void LateUpdate()
	{
		animator.SetFloat(forwardHash, input.move.y);
		animator.SetFloat(sideHash, Mathf.Abs(input.move.x));
	}


	public void SetBoolFalse(string name)
	{
		animator.SetBool(name, false);
	}
	public void SetBoolTrue(string name)
	{
		animator.SetBool(name, true);
	}
}
