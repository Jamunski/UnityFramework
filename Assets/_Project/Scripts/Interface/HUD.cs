/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 13/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * 
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
	private GameObject HealthBar;
	private GameObject ManaBar;
	private GameObject StaminaBar;

	private GameObject HealthPool;
	private GameObject ManaPool;
	private GameObject StaminaPool;

	private const float MAX_BAR_LENGTH = 2800;

	public Player m_Player;

	void Awake()
	{
		HealthBar = GameObject.Find(gameObject.name + "/HUDcanvas/TopLeft/HealthBar");
		ManaBar = GameObject.Find(gameObject.name + "/HUDcanvas/TopLeft/ManaBar");
		StaminaBar = GameObject.Find(gameObject.name + "/HUDcanvas/TopLeft/StaminaBar");

		HealthPool = GameObject.Find(gameObject.name + "/HUDcanvas/TopLeft/HealthBar/HealthPool");
		ManaPool = GameObject.Find(gameObject.name + "/HUDcanvas/TopLeft/ManaBar/ManaPool");
		StaminaPool = GameObject.Find(gameObject.name + "/HUDcanvas/TopLeft/StaminaBar/StaminaPool");

		//m_Player = GameObject.FindObjectOfType<Player>(); // Only works for one player...
	}

	public void UpdatePools()
	{
		Debug.Log(m_Player.name);
		Debug.Log(m_Player.m_PlayerStatistics.m_Stats.HealthTotal + " " + gameObject.name);
		//TODO: Fix Divide by zero here...
		if (m_Player.m_PlayerStatistics.m_Stats.HealthTotal != 0)
		{
			HealthPool.transform.localScale = new Vector3(m_Player.m_PlayerStatistics.m_Pools.Health / m_Player.m_PlayerStatistics.m_Stats.HealthTotal, 1.0f, 0.0f);
			ManaPool.transform.localScale = new Vector3(m_Player.m_PlayerStatistics.m_Pools.Mana / m_Player.m_PlayerStatistics.m_Stats.ManaTotal, 1.0f, 0.0f);
			StaminaPool.transform.localScale = new Vector3(m_Player.m_PlayerStatistics.m_Pools.Stamina / m_Player.m_PlayerStatistics.m_Stats.StaminaTotal, 1.0f, 0.0f);
		}
	}

	public void UpdateBars()
	{
		//Scale the bars based on the max values of each pool... bar caps at 2800...
		//HealthBar.transform.localScale = new Vector3(m_Player.m_PlayerStatistics.Stats.HealthTotal / MAX_BAR_LENGTH, 1.0f, 0.0f);

		//HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2((m_Player.m_PlayerStatistics.Stats.HealthTotal / MAX_BAR_LENGTH * 540) - 540, 0);

		HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Player.m_PlayerStatistics.m_Stats.HealthTotal / MAX_BAR_LENGTH * 540, 0);
		ManaBar.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Player.m_PlayerStatistics.m_Stats.ManaTotal / MAX_BAR_LENGTH * 540, 0);
		StaminaBar.GetComponent<RectTransform>().sizeDelta = new Vector2(m_Player.m_PlayerStatistics.m_Stats.StaminaTotal / MAX_BAR_LENGTH * 540, 0);

	}

	public void DisplayVictory()
	{
	}

	public void DisplayGameOver()
	{
	}
}