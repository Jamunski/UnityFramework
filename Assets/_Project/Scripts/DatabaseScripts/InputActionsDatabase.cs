using System.Collections.Generic;
using UnityEngine;

public class InputActionsDatabase : ScriptableObject
{
    #region Statics
    private const string PATH = "Databases/inputActions_database";

	private static InputActionsDatabase _instance;
	public static InputActionsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
				_instance = Resources.Load<InputActionsDatabase>(PATH);
            }
            return _instance;
        }
    }
    #endregion
	public List<InputActions> Actions;
}

[System.Serializable]
public class InputActions
{
	public string Name;
	public InputXBOX defaultXBOX;
	public InputPC defaultPC;
}