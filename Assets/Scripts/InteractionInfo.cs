using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
	Hover,
	Grab,
	Mix_Chemicals,
	Place
}
public class InteractionInfo : MonoBehaviour
{
	Dictionary<string, Interactable> participatingObjects;
	InteractionType interactionType;
}