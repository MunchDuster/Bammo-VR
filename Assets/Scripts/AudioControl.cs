using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioControl : MonoBehaviour
{
	private AudioSource source;
	[SerializeField]
	private bool isMusic;

    // Start is called before the first frame update
    private void Start()
    {
		source = GetComponent<AudioSource>();
		if(isMusic)
		{
			GameSettings.current.OnMusicVolumeChanged += OnChanged;
		}
		else
		{
			GameSettings.current.OnFXVolumeChanged += OnChanged;
		}
        
    }

	//Once is called when the type of colume matching this is updated
	private void OnChanged(float value)
	{
		source.volume = value;
	}
	// OnDestroy is called before an object is destroyed
	private void OnDestroy() 
	{
		if(isMusic)
		{
			GameSettings.current.OnMusicVolumeChanged -= OnChanged;
		}
		else
		{
			GameSettings.current.OnFXVolumeChanged -= OnChanged;
		}
	}

	// Update is called once per frame
	private void Update() 
	{
		source.pitch = Time.timeScale;
	}
}
