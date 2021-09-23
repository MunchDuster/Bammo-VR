using UnityEngine;
using UnityEngine.Events;

public class EndLevel : MonoBehaviour
{
    public UnityEvent OnLevelEnd;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject player = other.gameObject;
            Debug.Log(player);
            //Disable the player movement
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            movement.enabled = false;
            
            //Unlock the player cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        
            OnLevelEnd.Invoke();
        }
    }
}
