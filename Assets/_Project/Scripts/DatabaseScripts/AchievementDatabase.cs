using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AchievementDatabase : ScriptableObject
{
    #region Statics
	private const string PATH = "Databases/achievement_database";

    private static AchievementDatabase _instance;
    public static AchievementDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<AchievementDatabase>(PATH);
            }
            return _instance;
        }
    }
    #endregion

    public List<Achievement> achievements;
}