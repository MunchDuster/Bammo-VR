using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
	private Slider loadingSlider;
	[SerializeField]
	private TextMeshProUGUI loadingText;
	[SerializeField]
	private UnityEvent OnLoadScene;
    
    public void OpenScene(string sceneName)
	{
		OnLoadScene.Invoke();
		StartCoroutine(LoadAsync(sceneName));
	}
	
	private IEnumerator LoadAsync(string sceneName)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
		
		while(!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / 0.9f);
			loadingSlider.value = progress;
			loadingText.text = ((int)(progress * 100)).ToString() + "%";
			yield return null;
		}
	}
}
