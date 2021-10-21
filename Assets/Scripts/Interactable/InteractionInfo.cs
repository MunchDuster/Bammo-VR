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
	public InteractionType type;
	public string message;

	public static InteractionInfo Success(string _message)
	{
		return new InteractionInfo(InteractionType.Success, _message);
	}
	public static InteractionInfo Problem(string _message)
	{
		return new InteractionInfo(InteractionType.Problem, _message);
	}
	public static InteractionInfo Info(string _message)
	{
		return new InteractionInfo(InteractionType.Info, _message);
	}

	private InteractionInfo(InteractionType _type, string _message)
	{
		type = _type;
		message = _message;
	}
}