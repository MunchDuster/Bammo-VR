using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit()
	{
		Application.Quit();
	}
	public void OpenScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
