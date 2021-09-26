using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayList : MonoBehaviour
{
	
	public bool shufflePlay = true;
	public AudioClip[] clips;

    private AudioSource source;
	private int index;

	private void Start() 
	{
		if(clips.Length > 0)
		{
			source = GetComponent<AudioSource>();
			index = (shufflePlay && clips.Length > 1) ? Random.Range(0,clips.Length - 1) : 0;
			
			StartCoroutine(LoopPlayList());
		}
	}
	private IEnumerator LoopPlayList()
	{
		while(true)
		{
			source.Stop();
			source.clip = clips[index];
			source.Play();
			yield return new WaitForSeconds(source.clip.length);

			index++;
			if(index == clips.Length) index = 0;
		}
	}
}
