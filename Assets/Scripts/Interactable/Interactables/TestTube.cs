using UnityEngine;

public class TestTube : Interactable
{
    [SerializeField]
    private GameObject contentsGameobject;
	[SerializeField]
	private GameObject precipitateGameobject;
	[SerializeField]
	private GameObject BubbleGameobject;
    
    [HideInInspector]
    public Chemical contents
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
    
    private Chemical _contents;
    
    
    public override void Interact(Interactable other)
    {
        MixWithChemical(other as TestTube);
    }
    public override InteractionInfo WouldInteract(Interactable other)
    {
        if(other.GetType().Name == "TestTube")
        {
            if(_contents != null)
            {
                return InteractionInfo.Success;
            }
            else
            {
                return InteractionInfo.Problem("Cant mix with nothing.");
            }
        }
        else
        {
            return InteractionInfo.Problem("Test tube can only interact with other test tubes and chemicals.");
        }
    }
    
    
    private void MixWithChemical(TestTube other)
    {
        
        //Find new mixture created from mixing the contents of this and other test tubes.
        Chemical newIon = contents.mix(other.contents);
        
        //Now this test tube is empty
        contents = null;
        //Set the new mixture of chemicals to the other test tube
        other.contents = (newIon != null)? newIon : new Chemical();
    }
    private void TakeChemical(ChemicalContainer container)
    {
        //set contents to the contents of the chemicalContainer
        contents = container.contents;
    }
    private void OnContentsChanged()
    {
        if(_contents != null)
        {
            //show liquid in test tube
            contentsGameobject.SetActive(true);
            
            //update color of contents
            contentsGameobject.GetComponent<Renderer>().material.color = _contents.contentsColor;
            
            //show precipitate if needed
            Debug.Log("New Contents: " + _contents);
			if(_contents.hasPrecipitate)
			{
				//show precipitate in test tube
				precipitateGameobject.SetActive(true);
				//make it the correct color
            	precipitateGameobject.GetComponent<Renderer>().material.color = _contents.precipitateColor;
			}
			else
			{
				//hide the precipitate
				precipitateGameobject.SetActive(false);
			}
            
			//show bubbles if necessary
			if(_contents.bubbles)
			{
				BubbleGameobject.SetActive(true);
			}
			else
			{
				BubbleGameobject.SetActive(false);
			}
        }
        else
        {
            //hide liguid in test tube if not already
            if(!contentsGameobject.activeSelf)
            {
                contentsGameobject.SetActive(false);
                precipitateGameobject.SetActive(false);
				BubbleGameobject.SetActive(false);
            }
        }
    }
    
}
