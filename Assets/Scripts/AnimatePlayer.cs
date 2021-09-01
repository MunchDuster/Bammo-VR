using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
	public InputManager input;
	public Animator animator;

	private int forwardHash;
	private int sideHash;
	//Start is called before first update
	private void Start()
	{
		forwardHash = Animator.StringToHash("Forward");
		sideHash = Animator.StringToHash("Sideways");
	}
    // Update is called once per frame
    private void LateUpdate()
    {
		animator.SetFloat(forwardHash, input.move.y);
		animator.SetFloat(sideHash, Mathf.Abs(input.move.x));
    }
}
