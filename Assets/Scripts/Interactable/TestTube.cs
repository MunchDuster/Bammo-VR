using UnityEngine;

public class TestTube : Interactable
{
    [SerializeField]
    private GameObject contentsGameobject;
    
    [HideInInspector]
    public Ion contents
    {
        get 
        {
            return _contents; 
        }
        set 
        {
            _contents = value;
            OnContentsChanged();
        }
    }
    
    private Ion _contents;
    
    
    public override void Interact(Interactable other)
    {
        switch(other.GetType().Name)
        {
            case "TestTube":
                MixWithChemical(other as TestTube);
                break;
            case "ChemicalContainer":
                TakeChemical(other);
                break;
        }
    }
    public override InteractionInfo WouldInteract(Interactable other)
    {
        if(other  == null) return InteractionInfo.None;
        
        Debug.Log("ODER ITEM TYPE " + other.GetType().Name);
        
        return InteractionInfo.Success;
    }
    
    
    private void MixWithChemical(TestTube other)
    {
        //Find new mixture created from mixing the contents of this and other test tubes.
        Ion newIon = contents.mix(other.contents);
        
        //Now this test tube is empty
        contents = null;
        //Set the new mixture of chemicals to the other test tube
        other.contents = (newIon != null)? newIon : new SimpleIon();
    }
    private void TakeChemical(Interactable other)
    {
        //set contents to the contents of the chemicalContainer
        //contents = other.
    }
    private void OnContentsChanged()
    {
        if(_contents != null)
        {
            //show liguid in test tube if not already
            if(contentsGameobject.activeSelf)
            {
                contentsGameobject.SetActive(true);
            }
            //update color of contents
            contentsGameobject.GetComponent<Renderer>().material.color = _contents.color;
        }
        else
        {
            
        }
    }
    
}
