using UnityEngine;

[CreateAssetMenu(fileName = "Simple Ion", menuName = "ScriptableObjects/SimpleIon", order = 1)]
public class SimpleIon : Ion
{
    [System.Serializable]
    public struct part
    {
        public Element ion;
        public int number;
    }
    public int charge;
    public part cation;
    public part anion;
}
