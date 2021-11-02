using System;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
	//Sliders to control game settings
	public Slider musicVolumeSlider;
	public Slider fxVolumeSlider;
	public Slider brightnessSlider;
	public Slider sensitivitySlider;
	public Toggle motionBlurToggle;

	//Start is called before the first frame update
	private void Start()
	{
		//Listen for change of value in sliders
		ListenSlider(musicVolumeSlider, (value) => { GameSettings.current.musicVolume = value; });
		ListenSlider(fxVolumeSlider, (value) => { GameSettings.current.fxVolume = value; });
		ListenSlider(brightnessSlider, (value) => { GameSettings.current.brightness = value * 1.5f - 0.9f; });
		ListenSlider(sensitivitySlider, (value) => { GameSettings.current.sensitivity = value * 2; });

		//Listen for change of value in checkboxes
		ListenToggle(motionBlurToggle, (value) => { GameSettings.current.motionBlur = value; });
	}

	//Listener functions, assigns an action to a UI OnValueChangedEvent.
	public void ListenSlider(Slider slider, Action<float> onchange)
	{
		slider.onValueChanged.AddListener(delegate { onchange(slider.value); });
	}
	public void ListenToggle(Toggle toggle, Action<bool> onchange)
	{
		toggle.onValueChanged.AddListener(delegate { onchange(toggle.isOn); });
	}
}
