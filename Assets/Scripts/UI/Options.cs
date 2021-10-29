using System;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
	//Sliders to control game settings
	public Slider musicVolumeSlider;
	public Slider fxVolumeSlider;
	public Slider textSizeSlider;
	public Slider sensitivitySlider;
	public Toggle motionBlurToggle;

	//Start is called before the first frame update
	private void Start()
	{
		//Listen for change of value in sliders
		ListenSlider(musicVolumeSlider, (value) => { GameSettings.current.musicVolume = value; });
		ListenSlider(fxVolumeSlider, (value) => { GameSettings.current.fxVolume = value; });
		ListenSlider(textSizeSlider, (value) => { GameSettings.current.textSize = 1 + (0.5f * value - 0.25f); });
		ListenSlider(sensitivitySlider, (value) => { GameSettings.current.sensitivity = value; });

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
