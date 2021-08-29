using System;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Volume))]
public class PostProcessingControl : MonoBehaviour
{
	private Volume volume;
	private MotionBlur motionBlur;

    // Start is called before the first frame update
    private void Start()
    {
		//get volume in gameobject
		volume = GetComponent<Volume>();
		//add listener to gamesettings
        GameSettings.current.OnMotionBlurChanged += OnChanged;
		
		//get motionblur class, if not found then log exception.
		if(!volume.profile.TryGet(out motionBlur))
		{
			Debug.LogError(new Exception("No MotionBlur Override In Post Processing Volume."));
		}

		//update to current settings now
		//OnChanged(GameSettings.current.motionBlur);
    }

	private void OnChanged(bool enabled)
	{
		motionBlur.intensity.value = (enabled) ? 1 : 0;
	}

	// OnDestroy is called before an object is destroyed
	private void OnDestroy() 
	{
		//remove listener
		GameSettings.current.OnMotionBlurChanged -= OnChanged;
	}
}
