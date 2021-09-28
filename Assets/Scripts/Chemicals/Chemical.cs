using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Chemical", menuName = "Chemical", order = 1)]
public class Chemical: ScriptableObject
{
    [System.Serializable]
    private struct Reaction
    {
        public Chemical product;
        public Chemical reactant;
    }
    public Chemical mix(Chemical other)
    {
        foreach(Reaction reaction in reactions)
        {
            if(reaction.reactant == other)
            {
                return reaction.product;
            }
        }
        return null;
    }
    
    [SerializeField]
    private Reaction[] reactions;
    
    public string symbol;
    public Color contentsColor;
    
    public bool hasPrecipitate;
    
    public Color precipitateColor;

	public bool bubbles;
    
    public bool makesLitmusBlue;
}