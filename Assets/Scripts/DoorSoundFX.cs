using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundFX : MonoBehaviour
{
	[SerializeField]
	private AudioSource audioSource;
	[SerializeField]
	private AudioClip openDoorSound;
	[SerializeField]
	private AudioClip closeDoorSound;
	[SerializeField]
	private AudioClip lockDoorSound;
	[SerializeField]
	private AudioClip unlockDoorSound;

	public void PlaySound(AudioClip clip)
	{
		audioSource.Stop();
		audioSource.clip = clip;
		audioSource.Play();
	}
	public void OnDoorOpen()
	{

	}
}
