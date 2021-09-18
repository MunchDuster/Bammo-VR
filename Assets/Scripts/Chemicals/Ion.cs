using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ion : ScriptableObject
{
    [System.Serializable]
    public struct Reaction {
        public Ion other;
        public Ion result;
    }
    public enum State
    {
        Solution,
        Precipitate,
        Aqueous
    }
    public enum Type
    {
        Known,
        Unknown,
        UnknownToUser
    }
    
    public State state;
    public Reaction[] reactions;
    public Color color = Color.white;
    
    [HideInInspector]
    public Type type = Type.Known;
    
    public Ion mix(Ion other)
    {
        foreach(Reaction reaction in reactions)    
        {
            if(reaction.other == other)
            {
                return reaction.result;
            }
        }
        return null;
    }
    public Ion()
    {
        type = Type.Unknown;
    }
}
