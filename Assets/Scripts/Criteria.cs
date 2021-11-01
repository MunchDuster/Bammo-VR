using UnityEngine;
using UnityEngine.Events;

public class Criteria : MonoBehaviour
{

	public delegate void Event(bool value);
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
			OnCriteriaMet(value);
		}
	}

	public string meetRequirement;
}