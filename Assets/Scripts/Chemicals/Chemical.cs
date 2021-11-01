using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Chemical", menuName = "Chemical", order = 1)]
public class Chemical : ScriptableObject
{
	[System.Serializable]
	private struct Reaction
	{
		public Chemical product;
		public Chemical reactant;
	}
	public Chemical mix(Chemical other)
	{
		Debug.Log(name + " is reacting with " + other.name);
		foreach (Reaction reaction in reactions)
		{
			if (reaction.reactant == other)
			{
				return reaction.product;
			}
		}
		return null;
	}

	[SerializeField]
	private Reaction[] reactions;

	public string symbol;
	public Color contentsColor = Color.white;

	public bool hasPrecipitate;

	public Color precipitateColor = Color.white;

	public bool bubbles;

	public bool makesLitmusBlue;

	//Quick and dirty variables for the computer to check for correct answer
	public string name;
	public string charge;
}