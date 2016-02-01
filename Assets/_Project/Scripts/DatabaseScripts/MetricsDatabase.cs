using UnityEngine;

public class MetricsDatabase : ScriptableObject
{
	#region Statics
	private const string PATH = "Databases/metrics_database";

	private static MetricsDatabase _instance;
	public static MetricsDatabase Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Resources.Load<MetricsDatabase>(PATH);
			}
			return _instance;
		}
	}
	#endregion

	public DataForever data;
}