using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void UpdateEvent();
    
    public UpdateEvent OnUpdate;
    public UpdateEvent OnLateUpdate;
    
    public UpdateEvent OnFixedUpdate;
    
    //Start is called before the first frame update
    private void Start() 
    {
        OnUpdate += Empty;
        OnLateUpdate += Empty;
        OnFixedUpdate += Empty;
    }
    //Empty is used for initializing the delegates
    void Empty() {}
    
    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

	// LateUpdate is called after updatte
	private void LateUpdate() 
	{
        OnLateUpdate();
	}
    
    //FixedUpdate is called once per physics loop
    private void FixedUpdate() 
    {
        OnFixedUpdate();
    }
}
