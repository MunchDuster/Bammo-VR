using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public delegate void UpdateEvent();
    
    public UpdateEvent OnEarlyUpdate;
    public UpdateEvent OnUpdate;
    public UpdateEvent OnLateUpdate;
    
    public UpdateEvent OnEarlyFixedUpdate;
    public UpdateEvent OnFixedUpdate;
    public UpdateEvent OnLateFixedUpdate;
    
    //Start is called before the first frame update
    private void Start() 
    {
        OnEarlyUpdate += Empty;
        OnUpdate += Empty;
        OnLateUpdate += Empty;
    
        OnEarlyFixedUpdate += Empty;
        OnFixedUpdate += Empty;
        OnLateFixedUpdate += Empty;
    }
    //Empty is used for initializing the delegates
    void Empty() {}
    
    // Update is called once per frame
    void Update()
    {
        OnEarlyUpdate();
        OnUpdate();
        OnLateUpdate();
    }
    
    //LateUpdate is called once per physics loop
    private void LateUpdate() 
    {
        OnEarlyFixedUpdate();
        OnFixedUpdate();
        OnLateFixedUpdate();    
    }
}
