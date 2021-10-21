using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InductionMenu : MonoBehaviour
{
    public void Next()
	{
		GetComponent<Animator>().SetTrigger("Next");
		StartCoroutine(ResetTrigger());
	}
	IEnumerator ResetTrigger()
	{
		yield return new WaitForSeconds(0.5f);
		GetComponent<Animator>().ResetTrigger("Next");
	}
}
