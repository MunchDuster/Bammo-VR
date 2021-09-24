using UnityEngine;
using UnityEngine.Events;

public class SettingsPanel : MonoBehaviour
{
	public UnityEvent OnOpen;
	public UnityEvent OnExit;
    private void Show() 
	{
		if(OnOpen != null) OnOpen.Invoke();
		Time.timeScale = 0;
	}
	public void Hide()
	{
		if(OnExit != null) OnExit.Invoke();
		Time.timeScale = 1;
	}
}
