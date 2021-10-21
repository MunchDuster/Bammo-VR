using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    public string setText;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = setText;
    }
}
