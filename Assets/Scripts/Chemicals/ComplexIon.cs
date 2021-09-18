using UnityEngine;

[CreateAssetMenu(fileName = "ComplexIon", menuName = "ScriptableObjects/ComplexIon", order = 3)]
public class ComplexIon : Ion
{
    public int netCharge;
    public Ion cation;
    public Ion anion;
    public int number = 1;
    
}
