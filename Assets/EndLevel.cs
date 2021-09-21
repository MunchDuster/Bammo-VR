using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour
{
    public UnityEvent OnLevelEnd;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            OnLevelEnd.Invoke();
        }
    }
}
