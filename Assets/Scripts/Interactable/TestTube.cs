using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTube : Interactable
{
    public override void Interact(Interactable other)
    {
        
    }
    public override InteractionInfo WouldInteract(Interactable other)
    {
        TestTube otherAsTestTube = other as TestTube;
        Debug.Log("otherAsTestTube " + otherAsTestTube);
        
        return InteractionInfo.Success;
    }
}
