using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
	None,
	Info,
	Problem,
	Success
}
public class InteractionInfo 
{
	public static InteractionInfo None = new InteractionInfo(InteractionType.None, null);
	public static InteractionInfo Success = new InteractionInfo(InteractionType.Success, null);
	public InteractionType type;
	public string message;

	public InteractionInfo(InteractionType _type, string _message)
	{
		type = _type;
		message = _message;
	}
	public static InteractionInfo Problem(string _message)
	{
		return new InteractionInfo(InteractionType.Problem, _message);
	}
	public static InteractionInfo Info(string _message)
	{
		return new InteractionInfo(InteractionType.Info, _message);
	}
}