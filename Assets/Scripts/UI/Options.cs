using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Options : MonoBehaviour
{
	public Slider musicVolumeSlider;
	public Slider fxVolumeSlider;
	public Slider textSizeSlider;
	public Slider sensitivitySlider;
	public Toggle motionBlurToggle;

	private void Start() 
	{
		//Listen for change of value in sliders
		ListenSlider(musicVolumeSlider, (value) => {GameSettings.current.musicVolume = value;});
		ListenSlider(fxVolumeSlider, (value) => {GameSettings.current.fxVolume = value;});
		ListenSlider(textSizeSlider, (value) => {GameSettings.current.textSize = value;});
		ListenSlider(sensitivitySlider, (value) => {GameSettings.current.sensitivity = value;});

		//Listen for change of value in checkboxes
		ListenToggle(motionBlurToggle, (value) => {GameSettings.current.motionBlur = value;});
	}

	//Listener functions, assigns an action to a UI OnValueChangedEvent.
	public void ListenSlider(Slider slider, Action<float>  onchange )
	{
		slider.onValueChanged.AddListener(delegate{onchange(slider.value);});
	}
	public void ListenToggle(Toggle toggle, Action<bool>  onchange )
	{
		toggle.onValueChanged.AddListener(delegate{onchange(toggle.isOn);});
	}
	
}
