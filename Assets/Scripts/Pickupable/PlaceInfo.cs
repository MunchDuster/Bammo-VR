public enum PlacementType
{
	None,
	Info,
	Problem,
	Success
}
public class PlaceInfo
{
	public static PlaceInfo None = new PlaceInfo(PlacementType.None, null);
	public PlacementType type;
	public string message;


	public static PlaceInfo Problem(string _message)
	{
		return new PlaceInfo(PlacementType.Problem, _message);
	}
	public static PlaceInfo Success(string _message)
	{
		return new PlaceInfo(PlacementType.Success, _message);
	}
	public static PlaceInfo Info(string _message)
	{
		return new PlaceInfo(PlacementType.Info, _message);
	}

	private PlaceInfo(PlacementType _type, string _message)
	{
		type = _type;
		message = _message;
	}
}
