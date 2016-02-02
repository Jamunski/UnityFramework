using UnityEngine;
using UnityEditor;

public class DatabasesWindow : EditorWindow
{
	// Add menu named "My Window" to the Window menu
	[MenuItem("Window/Databases")]
	static void Init()
	{
		// Get existing open window or if none, make a new one:
		DatabasesWindow window = (DatabasesWindow)EditorWindow.GetWindow(typeof(DatabasesWindow));
		window.Show();
	}

	void OnGUI()
	{
		if (GUILayout.Button("Create Achievement Database"))
		{
			ScriptableObjectUtility.CreateAsset<AchievementDatabase>();
		}
        if (GUILayout.Button("Create InputActions Database"))
        {
			ScriptableObjectUtility.CreateAsset<InputActionsDatabase>();
        }
    }
}