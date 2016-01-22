using UnityEngine;
using System.Collections;
using UnityEditor;

public class AchievementManager : Observer
{
	//public Member Variables
	public AchievementDatabase m_AchievementDatabase;

	//Private Member Variables
	private static AchievementManager instance;

	private AchievementManager()
	{
		m_AchievementDatabase = Resources.Load<AchievementDatabase>("Achievements/achievement_database");
	}

	public static AchievementManager Instance
	{
		get
		{
			if (instance == null) { instance = new AchievementManager(); }
			return instance;
		}
	}




	public override void OnNotify(ref GameObject aEntity, GameEvent aEvent)
	{

	}
}

/* Notes:
Achievement events comprise multiple parts. The Achievement which they are linked to, the event message, the event type.

Achievements are objects which can be enabled or disabled, they cannot be acquired unless they are enabled. Once an achievement is acquired it is disabled
Once an achievement has been acquired a function anouncing this achievement will be called. 

The Achievement Manager will receive this event and handle what is to occur

Achievement: Jump off the third bridge while wearing no clothes before 20seconds have passed in the third level.
Observe physics for an event where the player is no longer on the ground -sustained
Observe level logic to identify the bridge the player was last standing on -sustained
Observe player equipment to identify whether or not they are wearing clothes -sustained
Observe time since level start to identify whether or not 20 seconds have passed -sustained
Observe the level manager to identify which level the player is currently in -toggled
 * All of these events are passed to the Achievement manager. The manager then decides which achievements care about these events
 * Once all events required for an achievement are true, the achievement is acquired.
Achievement: Get an accuracy of 100% on Hard difficulty on chapter 2
Observe Player hit rate
Event Types:
sustained: The event must be true every frame
toggled: The event must be triggered, once triggered it is true until triggered again
 * 
 * 
 * 
 * 
Achievement Manager:
Achivements[]
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Achievements are objects which can be acquired when certain conditions are met.
 * There are two lists, Acquireable and Acquired. Once an achievement is acquired it is removed from the acquireable list and added to
 * the acquired list.
 * Conditions will only be checked within the Acquireable list of achievements.
 * The Achievement Manager receives events via observing relevant GameObjects.
*/