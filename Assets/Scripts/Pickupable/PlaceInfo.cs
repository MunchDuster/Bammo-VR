public class PlaceInfo
{
	//the type of information used
	public enum Type
	{
		None,
		Problem,
		Success
	}

	public Type type;
	public string message;

	//used to create an instance
	public static PlaceInfo None = new PlaceInfo(Type.None, null);

	//static specific type conestuctors
	//example use in a function: return PlaceInfo.Success("Problem");
	//instead of using a normal constructor which would be like
	//example use in a function: return new PlaceInfo("Problem", PlaceInfo.PlacementType.Success);
	public static PlaceInfo Problem(string _message)
	{
		return new PlaceInfo(Type.Problem, _message);
	}
	public static PlaceInfo Success(string _message)
	{
		return new PlaceInfo(Type.Success, _message);
	}

	private PlaceInfo(Type _type, string _message)
	{
		type = _type;
		message = _message;
	}
}
