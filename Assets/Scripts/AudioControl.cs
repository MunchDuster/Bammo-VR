using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
	private AudioSource source;

    // Start is called before the first frame update
    private void Start()
    {
		source = GetComponent<AudioSource>();
        GameSettings.current.OnVolumeChanged += OnChanged;
    }
	private void OnChanged(float value)
	{
		source.volume = value;
	}
	// OnDestroy is called before an object is destroyed
	private void OnDestroy() 
	{
		GameSettings.current.OnVolumeChanged -= OnChanged;
	}
}
