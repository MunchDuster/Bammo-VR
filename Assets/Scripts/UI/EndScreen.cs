using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void UpdateText()
    {
        float time = Time.time;
        
        text.text = "Time taken: " + (time) + "s.";
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
