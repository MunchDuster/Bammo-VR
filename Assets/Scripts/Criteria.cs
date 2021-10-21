using UnityEngine;

public class Criteria : MonoBehaviour
{
	public delegate void Event();
	public Event OnCriteriaMet;

	private bool _hasBeenMet = false;
	public bool hasBeenMet
	{
		get
		{
			return _hasBeenMet;
		}
		set
		{
			_hasBeenMet = value;
			OnCriteriaMet();
		}
	}

	public string meetRequirement;
}