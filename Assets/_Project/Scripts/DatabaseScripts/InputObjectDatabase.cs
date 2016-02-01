using UnityEngine;

public class InputObjectDatabase : ScriptableObject
{
    #region Statics
    private const string PATH = "Databases/inputObj_database";

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

    public InputObj[] InputObjects;
}